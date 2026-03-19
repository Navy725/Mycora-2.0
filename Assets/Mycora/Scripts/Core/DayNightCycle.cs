using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [Header("Durée")]
    [SerializeField] private float dayDuration = 60f;
    [SerializeField] private float nightDuration = 40f;

    [Header("Lumière")]
    [SerializeField] private Light2D globalLight;

    [Header("Couleurs")]
    [SerializeField] private Color dayColor = new Color(1f, 0.894f, 0.710f);
    [SerializeField] private Color nightColor = new Color(0.102f, 0.102f, 0.243f);

    [Header("Intensités")]
    [SerializeField] private float dayIntensity = 1f;
    [SerializeField] private float nightIntensity = 0.15f;

    // État interne
    private float cycleTimer = 0f;
    private bool isDay = true;

    private void Update()
    {
        cycleTimer += Time.deltaTime;

        float currentDuration = isDay ? dayDuration : nightDuration;
        float t = cycleTimer / currentDuration;

        if (isDay)
        {
            globalLight.color = Color.Lerp(dayColor, nightColor, t);
            globalLight.intensity = Mathf.Lerp(dayIntensity, nightIntensity, t);
        }
        else
        {
            globalLight.color = Color.Lerp(nightColor, dayColor, t);
            globalLight.intensity = Mathf.Lerp(nightIntensity, dayIntensity, t);
        }

        if (cycleTimer >= currentDuration)
        {
            cycleTimer = 0f;
            isDay = !isDay;
        }
    }

    public bool IsDay() => isDay;
}