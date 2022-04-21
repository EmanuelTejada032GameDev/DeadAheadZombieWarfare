using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    public int couragePointsCost;
    public int movementSpeed = 1;

    [SerializeField] private Animator animator;

    [SerializeField] private int health;

    [SerializeField] private int damagePoints; 
    [SerializeField] private float attackInterval;

    Coroutine attackCoroutine;

    private Enemy enemyTarget;

    private void Update()
    {
        if (!enemyTarget)
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
        if(health <= 0)
        {
            Destroy(gameObject, 0.1f);
            return true;
        }
            return false;

    }

    public void dealDamage()
    {
       bool isEnemyDead = enemyTarget.takeDamage(damagePoints);
        if (isEnemyDead)
        {
            enemyTarget = null;
            StopCoroutine(attackCoroutine);
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
