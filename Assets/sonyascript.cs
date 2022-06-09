using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonyascript : MonoBehaviour
{

    [SerializeField]
    private GameObject bloodSplaterEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(bloodSplaterEffect, transform.position, Quaternion.identity);
    }
}
