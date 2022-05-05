using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    public int couragePointsCost;
    public int movementSpeed = 1;

    [SerializeField] private Animator animator;

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField]private HealthBarUI healthBar;

    [SerializeField] private int damagePoints; 
    [SerializeField] private float attackInterval;

    Coroutine attackCoroutine;

    public Enemy enemyTarget;


    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    private void Update()
    {
        if (enemyTarget == null && health > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        animator.Play("Run");
        transform.position += new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        //== Transform.Translate(Transform.right*movementSpeed*Time.deltaTime)
    }

    public bool takeDamage(int damageAmount)
    {
       
            health -= damageAmount;
            healthBar.SetHealth(health);
            if (health <= 0)
            {
                enemyTarget = null;
                StopCoroutine(attackCoroutine);
                GameObject healthBarCanvas = gameObject.transform.Find("Canvas").gameObject;
                if(healthBarCanvas != null )healthBarCanvas.SetActive(false);
                transform.position = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
                animator.Play("Death");
                Destroy(gameObject,3f);
                return true;
            }
        
            return false;

    }

    public void dealDamage()
    {
        if (enemyTarget != null)
        {
            bool isEnemyDead = enemyTarget.takeDamage(damagePoints);
            if (isEnemyDead)
            {
                enemyTarget = null;
                StopCoroutine(attackCoroutine);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemyTarget != null)
            return;

        if (collision.CompareTag("Enemy"))
        {
            enemyTarget = collision.GetComponent<Enemy>();
            attackCoroutine = StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        animator.Play("Attack_Light", 0, 0);
        yield return new WaitForSeconds(attackInterval);
        attackCoroutine = StartCoroutine(Attack());
    }
}
