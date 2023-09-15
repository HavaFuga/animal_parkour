using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool _isGrounded;
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
        ApplyMovement(); 
        ApplyRotation();
        ApplyGravity();
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime); 
    }

    private void ApplyRotation()
    {
        float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, angle, 0.0f));
    }

    private void ApplyGravity()
    {
        if (_isGrounded && _playerVelocity < 0.0f)
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
		
        _numberOfJumps++;
        _playerVelocity = jumpForce;    }

    private bool IsGrounded() => _characterController.isGrounded;
}























