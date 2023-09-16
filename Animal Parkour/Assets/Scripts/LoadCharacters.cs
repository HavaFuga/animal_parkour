using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacters : MonoBehaviour
{
    [SerializeField] private GameObject[] _characterPrefabs;
    

    private void Start()
    {
        _characterPrefabs[PersistentDataManager.SelectedCharacter].SetActive(true);
    }
}
