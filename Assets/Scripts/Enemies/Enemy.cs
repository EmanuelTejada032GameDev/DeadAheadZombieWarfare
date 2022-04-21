using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int movementSpeed = 1;

    [SerializeField] private Animator animator;

    [SerializeField] private int health;

    [SerializeField] private int damagePoints;
    [SerializeField] private float attackInterval;

    Coroutine attackCoroutine;

    private Troop troopTarget;

    private void Update()
    {
        if (!troopTarget)
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
        if (health <= 0)
        {
            Destroy(gameObject, 0.1f);
            return true;
        }
        return false;

    }

    public void dealDamage()
    {
        bool isTargetDead = troopTarget.takeDamage(damagePoints);
        if (isTargetDead)
        {
            troopTarget = null;
            StopCoroutine(attackCoroutine);
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
