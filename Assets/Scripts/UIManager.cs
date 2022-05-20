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
    private float _doubleTapPerkActiveTime = 4f;

    [SerializeField] private TextMeshProUGUI couragePointsUIText;

    private bool _canActivateDubleTapPerk = true;
    private bool _canActivateCourageBoxesRainPerk = true;
    private int courageBoxesToSpawn = 3;
    private int spawnedBoxes = 0;

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

    public void ActivateDoubleTapPerk()
    {
        if (_canActivateDubleTapPerk)
        {
            
            _canActivateDubleTapPerk = false;
            Troop[] deployedTroops = GameObject.FindObjectsOfType<Troop>();
            foreach (Troop troop in deployedTroops)
            {
                troop.damagePoints += troop.damagePoints;
                troop.troopMaterial.SetFloat("_OutlineAlpha", 1f);
            }
            Invoke("DeactivateDoubleTapPerk",_doubleTapPerkActiveTime);
        }
    }


    public void ActivateCouragePointsBoxesRainTapPerk()
    {
        if (_canActivateCourageBoxesRainPerk)
        {
            _canActivateCourageBoxesRainPerk = false;
            StartCoroutine("SpawnCouragePointsBoxes");
        }
    }
    public void DeactivateDoubleTapPerk()
    {
        Troop[] deployedTroops = GameObject.FindObjectsOfType<Troop>();
        foreach (Troop troop in deployedTroops)
        {
            troop.damagePoints /= 2;
            troop.troopMaterial.SetFloat("_OutlineAlpha", 0);
        }
        _canActivateDubleTapPerk = true;

    }

    

    IEnumerator SpawnCouragePointsBoxes()
    {
        Debug.Log("A box will spawn");
        yield return new WaitForSeconds(3f);
        if(spawnedBoxes < courageBoxesToSpawn)
        {
            spawnCorageBox();
            spawnedBoxes++;
            StartCoroutine(SpawnCouragePointsBoxes());
        } else
        {
            spawnedBoxes = 0;
            _canActivateCourageBoxesRainPerk = true;
        }
    }

    private void spawnCorageBox()
    {
        Vector3 randomSpawnPoint = courageBoxSpawnPoints[Random.Range(0, courageBoxSpawnPoints.Length)].transform.position;
        Instantiate(courageBox, randomSpawnPoint, Quaternion.identity);
    }
}
