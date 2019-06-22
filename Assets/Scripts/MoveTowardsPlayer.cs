using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    #region Fields

    Transform player;
    public float speed = 2.0f;

    #endregion

    #region Methods

    /// <summary>
    /// Finds the player and saves its transform
    /// </summary>
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    /// <summary>
    /// Chases the player
    /// </summary>
    void Update()
    {
        Vector3 delta = player.position - transform.position;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.position = transform.position + (delta * moveSpeed);
    }

    #endregion
}
