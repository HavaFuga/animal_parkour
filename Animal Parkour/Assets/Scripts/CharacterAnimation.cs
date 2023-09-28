using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GameObject))]

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private GameObject _character;    
    private CharacterController _characterController;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _character = this.gameObject;
    }

    private void Update()
    {
        animateJump();
    }

    private void animateJump()
    {
        if (_character.transform.position.y > 1)
        {
            _animator.SetBool("isJumping", true);
        }
        else
        {
            _animator.SetBool("isJumping", false);
        }
    }
    
}
