using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
