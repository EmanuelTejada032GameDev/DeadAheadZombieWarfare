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

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBarUI healthBar;
   

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
        maxEnemiesToSpawn = GameManager.Instance.enemiesToSpawn;
        StartCoroutine("SpawnEnemy");
    }

    private GameObject GetRandomEnemy()
    {
        //return enemies[Random.Range(0, enemies.Length)];       
        return enemies[0];
    }

    public bool takeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        return false;

    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnInterval);
        if(enemySpawned <= maxEnemiesToSpawn)
        {
            Instantiate(GetRandomEnemy(), enemySpawnPoint.position, Quaternion.identity);
            enemySpawned++;
            StartCoroutine(SpawnEnemy());
        }
       

    }

}
