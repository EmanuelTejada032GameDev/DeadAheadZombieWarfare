using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopSpawner : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBarUI healthBar;
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

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }
    
}
