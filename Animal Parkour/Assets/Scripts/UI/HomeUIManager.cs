using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    [SerializeField] private RulesUILogic rulesUILogicPrefab;

    private RulesUILogic _rulesPanel;
    private float _timeScale;

    private void Awake()
    {
        _rulesPanel = Instantiate(rulesUILogicPrefab, transform);
    }
    
    private void Start()
    {
        _rulesPanel.gameObject.SetActive(false);
        _rulesPanel.OkButtonPressed += OnOkButtonPressed;
    }
    
    
    public void StartGame()
    {
        Debug.Log("i do pres");
        _rulesPanel.gameObject.SetActive(true);
    }

    private void OnOkButtonPressed(object sender, EventArgs e)
    {
        SceneManager.LoadScene(1);
    }
}
