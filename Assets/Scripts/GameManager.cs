using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int couragePoints;
    public int enemiesToSpawn;

    [SerializeField] private Transform troopSpawner;

    public int CouragePoints{
        get => couragePoints;
        set
        {
            couragePoints = value;
            UIManager.Instance.UpdateUICouragePoints(couragePoints);
        } 
    }

    public GameManager()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Awake()
    {
        StartCoroutine("CouragePointsCounter");
    }
    public void spawnTroop(GameObject troop)
    {
        Troop troopScript = troop.GetComponent<Troop>();
        if(troopScript.couragePointsCost <= couragePoints)
        {
            CouragePoints -= troopScript.couragePointsCost;
            Instantiate(troop, troopSpawner.position, Quaternion.identity);
        }
    }

    IEnumerator CouragePointsCounter()
    {
        yield return new WaitForSeconds(1);
        if(couragePoints < 100)
        {
            CouragePoints+=2;
            StartCoroutine("CouragePointsCounter");
        }
    }

}
