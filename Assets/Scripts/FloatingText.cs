using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]private float destroyTime;
    public Vector3 startOffset = new Vector3(0,2f,0);
    private void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition = startOffset;
    }
}
