using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Cible")]
    [SerializeField] private Transform target;

    [Header("Lissage")]
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Offset")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}