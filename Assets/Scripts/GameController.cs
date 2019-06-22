using System.Collections;
using UnityEngine;

/// <summary>
/// Game Controller that handles enemy spawning, UI, and other similar functions.
/// </summary>
public class GameController : MonoBehaviour
{
    #region Fields

    public Transform Enemy;

    [Header("Wave Properties")]
    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = 0.25f;
    public float timeBeforeWaves = 2.0f;

    public int enemiesPerWave = 10;
    int currentNumberOfEnemies = 0;

    #endregion

    #region Methods

    /// <summary>
    /// Starts enemy spawner
    /// </summary>
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    /// <summary>
    /// Coroutine to spawn enemies
    /// </summary>
    /// <returns>returns a new WaitForSeconds</returns>
    IEnumerator SpawnEnemies()
    {
        // Gives time to player before spawning starts
        yield return new WaitForSeconds(timeBeforeSpawning);

        // Spawns enemies when there are none left
        while (true)
        {
            if (currentNumberOfEnemies <= 0)
            {
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    float randomDistance = Random.Range(10, 25);
                    Vector2 randomDirection = Random.insideUnitCircle;
                    
                    // spawns a new enemy at a random position
                    Vector2 enemyPosition = transform.position;
                    enemyPosition.x += randomDirection.x * randomDistance;
                    enemyPosition.y += randomDirection.y * randomDistance;
                    Instantiate(Enemy, enemyPosition, transform.rotation);
                    currentNumberOfEnemies++;

                    yield return new WaitForSeconds(timeBeforeWaves);
                }
            }
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }

    public void KilledEnemy()
    {
        currentNumberOfEnemies--;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
