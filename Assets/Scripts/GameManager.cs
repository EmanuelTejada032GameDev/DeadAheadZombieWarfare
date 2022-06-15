using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int couragePoints;
    public int enemiesToSpawn;


    public delegate void EnemyBaseDestroyed();
    public static event EnemyBaseDestroyed OnEnemyBaseDestroyed;

    Transform troopBaseTransform;


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
    public void MoveBus()
    {
        //animator.Play("MovingBus");
        StartCoroutine(MoveForward());
    }

    IEnumerator MoveForward()
    {
        yield return new WaitForSeconds(0.01f);
        troopBaseTransform.position = new Vector3(1,0,0);
        StartCoroutine("MoveForward");
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
