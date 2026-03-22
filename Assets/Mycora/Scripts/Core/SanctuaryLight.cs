using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SanctuaryLight : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private Light2D sanctuaryLight;
    [SerializeField] private DayNightCycle dayNightCycle;

    [Header("Intensité jour/nuit")]
    [SerializeField] private float dayIntensity = 0.3f;
    [SerializeField] private float nightIntensity = 1.5f;

    [Header("Pulsation")]
    [SerializeField] private float pulseSpeed = 2f;
    [SerializeField] private float pulseAmount = 0.2f;

    private float baseIntensity;

    private void Update()
    {
        // Intensité selon jour/nuit
        float targetIntensity = dayNightCycle.IsDay() ? dayIntensity : nightIntensity;
        baseIntensity = Mathf.Lerp(baseIntensity, targetIntensity, Time.deltaTime * 2f);

        // Effet de pulsation
        float pulse = Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        sanctuaryLight.intensity = baseIntensity + pulse;
    }
}