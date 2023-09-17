using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private float _rotationSpeed = 0.5f;
    private Vector3 spawn;
    private Transform spawnPoint;

    private int _focusedCharacter;

    private void Start()
    {
        transform.Rotate (0f,0f,0f);
        _focusedCharacter = 0;
        // ActivateCharacter();
    }   

    private void Update()
    {
        transform.Rotate (0f,_rotationSpeed*Time.deltaTime,0f);
    }

    private void ActivateCharacter()
    {
        GameObject c = _characters[_focusedCharacter];
        c.SetActive(true);
        _name.text = c.name;
    }

    public void NextCharacter()
    {
        _characters[_focusedCharacter].SetActive(false);
        _focusedCharacter = (_focusedCharacter + 1) % _characters.Length;
        ActivateCharacter();
    }

    public void PrevCharacter()
    {
        _characters[_focusedCharacter].SetActive(false);
        _focusedCharacter--;
        if (_focusedCharacter < 0)
        {
            _focusedCharacter += _characters.Length;
        }
        ActivateCharacter();
    }

    public void StartGame()
    {
        PersistentDataManager.SelectedCharacter = _focusedCharacter;
        SceneManager.LoadScene(2);
    }
}
