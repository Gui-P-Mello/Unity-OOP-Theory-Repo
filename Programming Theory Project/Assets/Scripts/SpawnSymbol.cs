using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSymbol : MonoBehaviour
{
    private float channelingTime = 3f;
    [SerializeField] GameObject enemyPrefab;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        StartCoroutine(SpawnChanneling());
    }

    IEnumerator SpawnChanneling()
    {
        yield return new WaitForSeconds(channelingTime);
        Instantiate(enemyPrefab, gameObject.transform.position, enemyPrefab.transform.rotation);
        Destroy(gameObject);
    }
}
