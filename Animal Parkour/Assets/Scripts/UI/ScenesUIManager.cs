using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class ScenesUIManager : MonoBehaviour
{
    [SerializeField] private OverlayUILogic overlayUILogicPrefab;
    [SerializeField] private PauseGameUILogic _pauseGameUILogicPrefab;
    [SerializeField] private FinishUILogic _finishUILogicPrefab;

    private OverlayUILogic _overlayPanel;
    private PauseGameUILogic _pauseMenuPanel;
    private FinishUILogic _finishPanel;
    private float _timeScale;

    private void Awake()
    {
        _overlayPanel = Instantiate(overlayUILogicPrefab, transform);
        _pauseMenuPanel = Instantiate(_pauseGameUILogicPrefab, transform);
        _finishPanel = Instantiate(_finishUILogicPrefab, transform);
    }
    
    private void Start()
    {
        _pauseMenuPanel.gameObject.SetActive(false);
        _finishPanel.gameObject.SetActive(false);
        _overlayPanel.gameObject.SetActive(true);
        
        _overlayPanel.PauseMenuButtonPressed += OnPauseMenuButtonPressed;
        _pauseMenuPanel.ResumeButtonPressed += OnResumeButtonPressed;
        PointManager.EndPointReached += OnEndPointReached;
    }

    private void OnEndPointReached(object sender, EventArgs e)
    {
        _timeScale = Time.timeScale;
        Time.timeScale = 0f;
        _pauseMenuPanel.gameObject.SetActive(false);
        _finishPanel.gameObject.SetActive(true);
    }

    private void OnPauseMenuButtonPressed(object sender, EventArgs e)
    {
        _timeScale = Time.timeScale;
        Time.timeScale = 0f;
        _overlayPanel.gameObject.SetActive(false);
        _pauseMenuPanel.gameObject.SetActive(true);
    }

    private void OnResumeButtonPressed(object sender, EventArgs e)
    {
        Time.timeScale = _timeScale;
        _pauseMenuPanel.gameObject.SetActive(false);
        _overlayPanel.gameObject.SetActive(true);
    }

    
}
