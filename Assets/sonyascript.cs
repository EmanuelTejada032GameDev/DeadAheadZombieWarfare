using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonyascript : MonoBehaviour
{

    [SerializeField]
    private GameObject bloodSplaterEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(Random.Range(5,9));
        }
        Destroy(gameObject);
        Instantiate(bloodSplaterEffect, transform.position, Quaternion.identity);
    }
}
