using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private Slider healthSlider;

    public void UpdateHealth(float healthPercent)
    {
        healthSlider.value = healthPercent;
    }
}