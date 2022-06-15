using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopSpawner : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] public float movementSpeed;
    [SerializeField] private HealthBarUI healthBar;

    public delegate void TroopBaseDestroyed();
    public static event TroopBaseDestroyed OnTroopBaseDestroyed;


    public Animator animator;

    public void Update()
    {
    }
    public bool takeDamage(int damageAmount)
    {
        health -= damageAmount;
        animator.Play("busHit");
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


    public void MoveBus()
    {
        animator.Play("MovingBus");
        StartCoroutine("MoveForward");
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    IEnumerator MoveForward()
    {
        yield return new WaitForSeconds(0.01f);
        transform.position += new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        StartCoroutine("MoveForward");
    }

}
