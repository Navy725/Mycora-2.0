using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float moveSpeed = 2f;

    [Header("Combat")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float damageRate = 1f;

    // Références
    private Transform target;
    private Rigidbody2D rb;
    private SanctuaryHealth sanctuaryHealth;
    private float damageTimer = 0f;
    private bool isInRange = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Transform sanctuaryTransform, SanctuaryHealth health)
    {
        target = sanctuaryTransform;
        sanctuaryHealth = health;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    private void Update()
    {
        if (!isInRange) return;

        damageTimer += Time.deltaTime;
        if (damageTimer >= damageRate)
        {
            damageTimer = 0f;
            sanctuaryHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sanctuary"))
        {
            isInRange = true;
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Sanctuary"))
        {
            isInRange = false;
        }
    }
}