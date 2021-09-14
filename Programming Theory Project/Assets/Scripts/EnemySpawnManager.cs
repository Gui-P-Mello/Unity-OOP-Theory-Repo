using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawnPrefab;
    [SerializeField] private GameObject rangedEnemySpawnPrefab;

    private float spawnRange = 47;
    private float startDelay = 0.5f;
    private float spawnInterval = 1.5f;
    private int maxSpawnAmount = 50;
    private int enemyCount;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount < maxSpawnAmount)
        {
            i++;
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0.5f, Random.Range(-spawnRange, spawnRange));
            if (i > 5)
            {
                i = 0;
            }
            if(i % 2 != 0)
            {
                Instantiate(enemySpawnPrefab, spawnPos, enemySpawnPrefab.transform.rotation);
            }
            else
            {
                Instantiate(rangedEnemySpawnPrefab, spawnPos, rangedEnemySpawnPrefab.transform.rotation);
            }

        }        
    }
}