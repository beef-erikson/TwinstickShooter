using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player control and logic
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    #region Fields

    // movement support
    public float PlayerSpeed = 4.0f;
    float currentSpeed = 0.0f;
    Vector3 lastMovement = new Vector3();

    // firing support
    public Transform shot;
    public float shotDistanceFromShipCenter = 0.2f;
    public float timeBetweenFires = 0.3f;
    public List<KeyCode> shootButton;
    float timeUntilNextFire = 0.0f;
    
    #endregion

    #region Methods

    /// <summary>
    /// Player rotation, movement, firing logic
    /// </summary>
    void Update()
    {
        // movement methods
        Rotation();
        Movement();

        // fire if button pressed and ready
        foreach (KeyCode key in shootButton)
        {
            if (Input.GetKey(key) && timeUntilNextFire <= 0)
            {
                timeUntilNextFire = timeBetweenFires;
                Shoot();
                break;
            }
        }

        timeUntilNextFire -= Time.deltaTime;
    }

    /// <summary>
    /// Rotates ship to face the mouse pointer
    /// </summary>
    void Rotation()
    {
        // gets world position from mouse
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        // gets delta from each axis and determines angle in degrees
        float deltaX = transform.position.x - worldPos.x;
        float deltaY = transform.position.y - worldPos.y;
        float angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;

        // sets ship's rotation
        Quaternion newRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        transform.rotation = newRotation;
    }

    /// <summary>
    /// Movement logic for player
    /// </summary>
    void Movement()
    {
        Vector3 movement = new Vector3();

        // checks inputs and normalizes
        movement.x += Input.GetAxis("Horizontal");
        movement.y += Input.GetAxis("Vertical");
        movement.Normalize();

        // checks for movement and moves if true
        if (movement.magnitude > 0)
        {
            currentSpeed = PlayerSpeed;
            transform.Translate(movement * Time.deltaTime * currentSpeed, Space.World);
            lastMovement = movement;
        }
        // otherwise, continue moving in same direction, slowing down per frame
        else
        {
            transform.Translate(lastMovement * Time.deltaTime * currentSpeed, Space.World);
            currentSpeed *= 0.9f;
        }
    }

    /// <summary>
    /// Fires shot at an initial position in front of ship
    /// </summary>
    void Shoot()
    {
        Vector3 shotPosition = transform.position;
        float shotRotationAngle = transform.localEulerAngles.z - 90;

        // positions and instantiate shot
        shotPosition.x += (Mathf.Cos(shotRotationAngle) * Mathf.Deg2Rad)
            * -shotDistanceFromShipCenter;
        shotPosition.y += (Mathf.Sin(shotRotationAngle) * Mathf.Deg2Rad)
            * -shotDistanceFromShipCenter;
        Instantiate(shot, shotPosition, transform.rotation);
    }
         
    #endregion
}
