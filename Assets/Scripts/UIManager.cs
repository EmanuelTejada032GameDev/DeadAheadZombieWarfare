using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI couragePointsUIText;

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

}
