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

        
        // if (Mouse.current.leftButton.wasPressedThisFrame)
        // {
        //     turn.x = Mouse.current.position.ReadValue().x;
        //     turn.y = Mouse.current.position.ReadValue().y;
        //
        // }
        //
        if (_characters.Length == 0) return;
        _target = _characters[PersistentDataManager.SelectedCharacter].transform;
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }   
}
