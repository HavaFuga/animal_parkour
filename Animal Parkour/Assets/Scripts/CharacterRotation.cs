using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private float _rotationSpeed = 20f;

    private Vector3 spawn;
    private Transform spawnPoint;

    private int _focusedCharacter;
    private Animator _animator;

    private void Start()
    {
        transform.Rotate (0f,0f,0f);
        InvokeRepeating(nameof(NextCharacter), 5f, 5f);
    }   

    private void Update()
    {
        transform.Rotate (0f,_rotationSpeed*Time.deltaTime,0f);
        _animator = GetComponentInChildren<Animator>();
        AnimationManager.ChangeAnimation(_animator, PersistentDataManager.PLAYER_IDLE);
    }

    private void ActivateCharacter()
    {
        GameObject c = _characters[_focusedCharacter];
        c.SetActive(true);
    }

    public void NextCharacter()
    {
        _characters[_focusedCharacter].SetActive(false);
        _focusedCharacter = (_focusedCharacter + 1) % _characters.Length;
        ActivateCharacter();
    }
}
