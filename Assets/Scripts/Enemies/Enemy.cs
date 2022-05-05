using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public int movementSpeed = 1;

    [SerializeField] private Animator animator;

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBarUI healthBar;

    [SerializeField] private int damagePoints;
    [SerializeField] private float attackInterval;

    Coroutine attackCoroutine;

    public Troop troopTarget;
    public TroopSpawner troopBase;


    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    private void Update()
    {
        if (troopTarget == null)
        {
            Move();
        }
    }

    private void Move()
    {
        animator.Play("Run");
        transform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
        //== Transform.Translate(-Transform.right*movementSpeed*Time.deltaTime)
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

    public void dealDamage()
    {
        if (troopTarget != null)
        {
            bool isTargetDead = troopTarget.takeDamage(damagePoints);
            if (isTargetDead)
            {
                troopTarget = null;
                StopCoroutine(attackCoroutine);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (troopTarget != null)
            return;

        if (collision.CompareTag("Troop"))
        {
            troopTarget = collision.GetComponent<Troop>();
            attackCoroutine = StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        animator.Play("Attack_Light");
        yield return new WaitForSeconds(attackInterval);
        attackCoroutine = StartCoroutine(Attack());
    }
}
