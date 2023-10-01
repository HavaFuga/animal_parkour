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

        _offset = new Vector3(0, 4, -10);
        Vector3 temp = transform.rotation.eulerAngles;
        temp.x = 15f;
        
        // is
        if (_target.position.y < -2)
        {
            _offset = new Vector3(0, 8f, -12);
            temp.x = 30.0f;
        }
        Vector3 targetPosition = Vector3.SmoothDamp(_target.position, _target.position + _offset, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(temp);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }   
}
