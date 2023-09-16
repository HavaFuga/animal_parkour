using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 _currentVelocity;
    
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float smoothTime;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }   
}
