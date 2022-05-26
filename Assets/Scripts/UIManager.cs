using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private int _doubleTapPerkActiveTime = 4;

    [SerializeField] private TextMeshProUGUI couragePointsUIText;
    [SerializeField] private int activePerkCounterUItValue = 0;
    [SerializeField] private GameObject _UIPanel;

    [SerializeField] private TextMeshProUGUI activePerkCounterUIText;

    [SerializeField] private GameObject doubleTapUIActiveTemplate;
    [SerializeField] private GameObject courageBoxUIActiveTemplate;







    private int courageBoxesToSpawn = 3;
    private int spawnedBoxes = 0;

    private bool _isPerkActive = false;
    private bool _doubleTapActive = false;

    [SerializeField]
    private GameObject courageBox;
    [SerializeField]
    private Transform[] courageBoxSpawnPoints;
    public UIManager()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateUICouragePoints(int newCouragePointsUITextValue)
    {
        couragePointsUIText.text = newCouragePointsUITextValue.ToString();
    }

    public void UpdateUIActiveItemCounter(int newActiveItemValue)
    {
        activePerkCounterUIText.text = $"0{newActiveItemValue}";
    }
    public void ActivateDoubleTapPerk()
    {
            if (_isPerkActive) return;
            activePerkCounterUItValue = _doubleTapPerkActiveTime;
            UpdateUIActiveItemCounter(activePerkCounterUItValue);
            StartCoroutine(activePerkCounter());
            doubleTapUIActiveTemplate.gameObject.SetActive(true);
            activePerkCounterUIText.gameObject.SetActive(true);
            _isPerkActive = true;
            _doubleTapActive = true;
             _UIPanel.gameObject.SetActive(false);
            Troop[] deployedTroops = GameObject.FindObjectsOfType<Troop>();
            foreach (Troop troop in deployedTroops)
            {
                if (troop.health > 0)
                {
                    troop.damagePoints += troop.damagePoints;
                    troop.GetComponent<SpriteRenderer>().material.SetFloat("_OutlineAlpha", 1f);
                }
               
            }
            Invoke("DeactivateDoubleTapPerk",_doubleTapPerkActiveTime);
        
    }


    public void ActivateCouragePointsBoxesRainTapPerk()
    {
        if (_isPerkActive) return;
        activePerkCounterUItValue = 9;
        UpdateUIActiveItemCounter(activePerkCounterUItValue);
        StartCoroutine(activePerkCounter());
        courageBoxUIActiveTemplate.gameObject.SetActive(true);
        activePerkCounterUIText.gameObject.SetActive(true);
        _UIPanel.gameObject.SetActive(false);
        _isPerkActive = true;
        StartCoroutine("SpawnCouragePointsBoxes");
    }
    public void DeactivateDoubleTapPerk()
    {
        //Troop[] deployedTroops = GameObject.FindObjectsOfType<Troop>();
        //foreach (Troop troop in deployedTroops)
        //{
        //    troop.damagePoints /= 2;
        //    troop.troopMaterial.SetFloat("_OutlineAlpha", 0);
        //}
        _isPerkActive = false;
        _doubleTapActive = false;
    }

    public bool isDoubleTapActive()
    {
        return _doubleTapActive;
    }
    

    IEnumerator SpawnCouragePointsBoxes()
    {
        yield return new WaitForSeconds(3f);
        if(spawnedBoxes < courageBoxesToSpawn)
        {
            spawnCorageBox();
            spawnedBoxes++;
            StartCoroutine(SpawnCouragePointsBoxes());
        } else
        {
            spawnedBoxes = 0;
            _isPerkActive = false;
        }
    }

    private void spawnCorageBox()
    {
        Vector3 randomSpawnPoint = courageBoxSpawnPoints[Random.Range(0, courageBoxSpawnPoints.Length)].transform.position;
        Instantiate(courageBox, randomSpawnPoint, Quaternion.identity);
    }


    IEnumerator activePerkCounter()
    {

        yield return new WaitForSeconds(1f);
        if(activePerkCounterUItValue > 0)
        {
            activePerkCounterUItValue--;
            UpdateUIActiveItemCounter(activePerkCounterUItValue);
            StartCoroutine(activePerkCounter());
        }
        else
        {
            activePerkCounterUIText.gameObject.SetActive(false);
            activePerkCounterUItValue = 0;
            StopCoroutine("activePerkCounter");
            doubleTapUIActiveTemplate.gameObject.SetActive(false);
            courageBoxUIActiveTemplate.gameObject.SetActive(false);
            _UIPanel.gameObject.SetActive(true);

        }

    }
}
