using UnityEngine;

/// <summary>
/// Shooting logic
/// </summary>
public class ShotBehaviour : MonoBehaviour
{
    #region Fields

    // shot support variables
    public float shotLifetime = 2.0f;
    public float shotSpeed = 5.0f;
    public int shotDamage = 1;

    #endregion

    #region Methods

    /// <summary>
    /// Destroys shot after shotLifetime has passed
    /// </summary>
    void Start()
    {
        Destroy(gameObject, shotLifetime);
    }

    /// <summary>
    /// Keeps shot moving in original direction
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * shotSpeed);
    }

    #endregion
}
