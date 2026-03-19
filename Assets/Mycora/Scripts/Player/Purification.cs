using UnityEngine;

public class Purification : MonoBehaviour
{
    [Header("Purification")]
    [SerializeField] private CorruptionManager corruptionManager;
    [SerializeField] private float purificationRate = 0.5f;

    private float purificationTimer = 0f;

    private void Update()
    {
        purificationTimer += Time.deltaTime;

        if (purificationTimer >= purificationRate)
        {
            purificationTimer = 0f;
            TryPurify();
        }
    }

    private void TryPurify()
    {
        corruptionManager.PurifyTile(transform.position);
    }
}