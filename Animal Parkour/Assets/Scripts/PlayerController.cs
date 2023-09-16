using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _direction;
    private float _currentVelocity;
    private CharacterController _characterController;
    private float _playerVelocity;
    private readonly float _gravityValue = -9.81f;
    private int _numberOfJumps;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private int maxNumberOfJumps = 2;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    private void FixedUpdate()
    {
        ApplyGravity();
        ApplyMovement(); 
        ApplyRotation();
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime); 
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;
        
        float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, angle, 0.0f));
    }

    private void ApplyGravity()
    {
       
        if (IsGrounded() && _playerVelocity < 0.0f)
        {
            _playerVelocity = -1.0f;
        }
        else
        {
            _playerVelocity += _gravityValue * Time.deltaTime;
        }
		
        _direction.y = _playerVelocity;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y).normalized;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _numberOfJumps >= maxNumberOfJumps) return;
        if (_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        _numberOfJumps++;
        _playerVelocity = jumpForce;    
    }

    private bool IsGrounded() => _characterController.isGrounded;

    // wait for character to land and then set 
    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);

        _numberOfJumps = 0;
    }
}
