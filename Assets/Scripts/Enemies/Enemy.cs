using System;
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

    [SerializeField]
    private GameObject bloodSplaterEffect;

    Coroutine attackCoroutine;

    public Troop troopTarget;
    public TroopSpawner troopBase;

    [SerializeField]
    private GameObject _floatingTextPrefab;


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
            Instantiate(bloodSplaterEffect, transform.position, Quaternion.identity);
            if (_floatingTextPrefab) ShowFloatingText(damageAmount);
            healthBar.SetHealth(health);
            if (health <= 0)
            {
                Destroy(gameObject);
                return true;
            }
            return false;

    }

    private void ShowFloatingText(int damageAmount)
    {
        var gameObj = Instantiate(_floatingTextPrefab, transform.position, Quaternion.identity, transform);
        gameObj.transform.localScale = new Vector3(-gameObj.transform.localScale.x, gameObj.transform.localScale.y, gameObj.transform.localScale.z);
        gameObj.GetComponent<TextMesh>().text = $"-{damageAmount.ToString()}";
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
