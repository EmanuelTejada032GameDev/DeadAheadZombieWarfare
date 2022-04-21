using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject[] enemies;
    [SerializeField] Transform enemySpawnPoint;
    public float spawnInterval;
    private int maxEnemiesToSpawn;
    private int enemySpawned;

    private void Start()
    {
       maxEnemiesToSpawn = GameManager.Instance.enemiesToSpawn;
       StartCoroutine("SpawnEnemy");
    }

    private GameObject GetRandomEnemy()
    {
        //return enemies[Random.Range(0, enemies.Length)];       
        return enemies[0];
    }

    IEnumerator SpawnEnemy()
    {
        Debug.Log("Should Spawn enemy");
        yield return new WaitForSeconds(spawnInterval);
        if(enemySpawned <= maxEnemiesToSpawn)
        {
            Instantiate(GetRandomEnemy(), enemySpawnPoint.position, Quaternion.identity);
            enemySpawned++;
            StartCoroutine(SpawnEnemy());
        }
       

    }

    


}
