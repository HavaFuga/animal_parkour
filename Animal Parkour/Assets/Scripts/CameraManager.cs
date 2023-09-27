using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    private Vector3 _currentVelocity;
    private InputAction _input;
    
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float smoothTime;
    private Transform _target;
    public Vector2 turn;

    private void Update()
    {
        if (_characters.Length == 0) return;
        _target = _characters[PersistentDataManager.SelectedCharacter].transform;

        Vector3 swimmingAngle = Vector3.zero;
        Vector3 swimmRotation = Vector3.zero;
        
        // is
        if (_target.position.y < 2)
        {
            swimmingAngle.y = 6;
            Debug.Log("is smaller than y < 2");
            swimmRotation.x = 20;
        }
        Vector3 targetPosition = _target.position + _offset + swimmingAngle;
        transform.Rotate(swimmRotation);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }   
}
