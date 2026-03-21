using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void UpdateHealth(float healthPercent)
    {
        if (healthSlider == null) return;
        healthSlider.value = healthPercent;
    }
}