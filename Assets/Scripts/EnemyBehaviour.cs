using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Fields

    public int Health = 2;

    #endregion

    #region Methods
    
    /// <summary>
    /// Takes away health and destroys if dead
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Hit by laser
        if (collision.gameObject.name.Contains("Laser"))
        {
            ShotBehaviour shot = collision.gameObject.GetComponent<ShotBehaviour>();
            Health -= shot.shotDamage;
            Destroy(collision.gameObject);
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    #endregion
}
