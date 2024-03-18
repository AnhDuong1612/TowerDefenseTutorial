using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    // 1 
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    // 1
    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScallingFactor = 0.75f;
   

    //2
    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    //1
    private int currentWave = 1;
    private bool isSpawning = false;
    private int enemiesLeftToSpawn;
    private float timeSinceLastSpawn;
    private int enemiesAlive;

    //1
    private void Start()
    {
        StartCoroutine(StartWave());
    }

    //2
    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    //2
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }


    //1
    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn>=(1f/enemiesPerSecond) && enemiesLeftToSpawn>0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            Endwave();
            //currentWave++;
            //if (currentWave == 2) return;
        }

        
    }

    private void Endwave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        //if (currentWave == 3) return;
        StartCoroutine(StartWave());
    }

    //1
    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        // tao ra mot ban sao cua prefab duoc dat o vi tri start point va khong co huong quay
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    //1
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    //1
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScallingFactor));
    }
}
