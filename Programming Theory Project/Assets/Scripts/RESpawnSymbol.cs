using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESpawnSymbol : MonoBehaviour
{
    private float channelingTime = 3f;
    [SerializeField] GameObject rangedEnemyPrefab;
    private void Start()
    {
        SpawnRangedEnemy();
    }

    private void SpawnRangedEnemy()
    {
        StartCoroutine(SpawnChanneling());
    }

    IEnumerator SpawnChanneling()
    {
        yield return new WaitForSeconds(channelingTime);
        Instantiate(rangedEnemyPrefab, gameObject.transform.position, rangedEnemyPrefab.transform.rotation);
        Destroy(gameObject);
    }
}
