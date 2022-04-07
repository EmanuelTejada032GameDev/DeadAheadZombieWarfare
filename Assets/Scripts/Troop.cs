using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
   public int couragePointsCost;
    public int movementSpeed = 1;


    private void Update()
    {
       transform.position +=  new Vector3(1,0,0) * movementSpeed * Time.deltaTime;
    }
}
