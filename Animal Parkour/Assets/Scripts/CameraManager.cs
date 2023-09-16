using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 _currentVelocity;
    
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float smoothTime;
    private Transform _target;

    private void Update()
    {
        if (_characters.Length == 0) return;
        _target = _characters[PersistentDataManager.SelectedCharacter].transform;
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }   
}
