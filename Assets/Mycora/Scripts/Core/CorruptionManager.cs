using UnityEngine;
using UnityEngine.Tilemaps;

public class CorruptionManager : MonoBehaviour
{
    [Header("Tilemaps")]
    [SerializeField] private Tilemap corruptionTilemap;

    public bool IsCorrrupted(Vector3 worldPosition)
    {
        Vector3Int cellPosition = corruptionTilemap.WorldToCell(worldPosition);
        return corruptionTilemap.HasTile(cellPosition);
    }

    public void PurifyTile(Vector3 worldPosition)
    {
        Vector3Int cellPosition = corruptionTilemap.WorldToCell(worldPosition);
        if (corruptionTilemap.HasTile(cellPosition))
        {
            corruptionTilemap.SetTile(cellPosition, null);
        }
    }

    public int GetCorruptionCount()
    {
        return corruptionTilemap.GetUsedTilesCount();
    }
}