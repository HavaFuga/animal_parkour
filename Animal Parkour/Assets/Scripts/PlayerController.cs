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

    [SerializeField] private float speed;
    [SerializeField] private float smoothTime = 0.05f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y).normalized;
    }
    
    float asdf = 5;
    private void FixedUpdate()
    {
        // if no direction is pressed returns either 1 or 0
        // so it wont turn to direction x again
        if (_input.sqrMagnitude == 0) return;
        
        float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, angle, 0.0f));
        
        _characterController.Move(_direction * speed * Time.deltaTime); 
    }
}























