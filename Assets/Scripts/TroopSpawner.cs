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

    public void spawnTroop(GameObject troop)
    {
        Troop troopScript = troop.GetComponent<Troop>();
        if (troopScript.couragePointsCost <= GameManager.Instance.couragePoints)
        {
            GameManager.Instance.CouragePoints -= troopScript.couragePointsCost;
            GameObject troopGO =  Instantiate(troop, transform.position, Quaternion.identity);
            if (UIManager.Instance.isDoubleTapActive())
            {
                troopGO.GetComponent<Troop>().damagePoints += troopGO.GetComponent<Troop>().damagePoints;
                troopGO.GetComponent<SpriteRenderer>().material.SetFloat("_OutlineAlpha", 1f);
            }
        }
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }
    
}
