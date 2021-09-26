using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minBounds, maxBounds;

    private void Start()
    {
        if (smoothing <= 0) Debug.LogWarning($"{name}'s smoothing is less than or equal to zero!");
        if (target == null) Debug.LogWarning($"{name} has no target to follow!");
    }
    
    private void LateUpdate()
    {
        if (target != null)
            if (transform.position != target.position) 
            {
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
                targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
    }
}
