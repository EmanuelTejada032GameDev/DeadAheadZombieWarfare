using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fillImage;

    public void SetMaxHealth(int maxHelathAmount)
    {
        slider.maxValue = maxHelathAmount;
        slider.value = maxHelathAmount;

        fillImage.color = gradient.Evaluate(1f); 
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fillImage.color = gradient.Evaluate(slider.normalizedValue); 
    }


}
