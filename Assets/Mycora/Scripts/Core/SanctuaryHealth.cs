using UnityEngine;
using UnityEngine.Events;

public class SanctuaryHealth : MonoBehaviour
{
    [Header("Vie")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    [Header("Dégâts")]
    [SerializeField] private float corruptionDamage = 5f;
    [SerializeField] private float damageRate = 1f;

    [Header("Événements")]
    public UnityEvent onDeath;
    public UnityEvent<float> onHealthChanged;

    private float damageTimer = 0f;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (isDead) return;

        damageTimer += Time.deltaTime;
        if (damageTimer >= damageRate)
        {
            damageTimer = 0f;
            TakeCorruptionDamage();
        }
    }

    private void TakeCorruptionDamage()
    {
        TakeDamage(corruptionDamage);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        onHealthChanged.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0f)
        {
            isDead = true;
            onDeath.Invoke();
        }
    }

    public void Heal(float amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        onHealthChanged.Invoke(currentHealth / maxHealth);
    }

    public float GetHealthPercent() => currentHealth / maxHealth;
}