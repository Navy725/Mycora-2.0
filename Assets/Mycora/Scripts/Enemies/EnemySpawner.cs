using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform sanctuaryTransform;
    [SerializeField] private SanctuaryHealth sanctuaryHealth;
    [SerializeField] private DayNightCycle dayNightCycle;

    [Header("Spawn")]
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float spawnRate = 5f;

    private float spawnTimer = 0f;

    private void Update()
    {
        if (dayNightCycle.IsDay()) return;

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = sanctuaryTransform.position + 
                                new Vector3(randomDirection.x, randomDirection.y, 0f) 
                                * spawnRadius;

        GameObject enemyGO = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyAI enemyAI = enemyGO.GetComponent<EnemyAI>();
        enemyAI.Initialize(sanctuaryTransform, sanctuaryHealth);
    }
}