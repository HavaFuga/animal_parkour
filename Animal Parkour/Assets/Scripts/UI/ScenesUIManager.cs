using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class ScenesUIManager : MonoBehaviour
{
    [SerializeField] private OverlayUILogic overlayUILogicPrefab;
    [SerializeField] private OverlayUILogic overlayUILogicPrefab;

    private OverlayUILogic _overlayPanel;
    private OverlayUILogic _overlayPanel;

    private void Awake()
    {
        _overlayPanel = Instantiate(overlayUILogicPrefab, transform);
    }

    private void Start()
    {
        _cartEditorPanel.gameObject.SetActive(false);
        _overlayPanel.EditCartButtonPressed += OnEditCartButtonPressed;
        _cartEditorPanel.LeaveEditorMenu += OnLeaveEditorMenu;
    }

    private void OnEditCartButtonPressed(object sender, EventArgs e)
    {
        _timeScale = Time.timeScale;
        Time.timeScale = 0f;
        _overlayPanel.gameObject.SetActive(false);
        _cartEditorPanel.gameObject.SetActive(true);
    }

    private void OnLeaveEditorMenu(object sender, EventArgs e)
    {
        Time.timeScale = _timeScale;
        _overlayPanel.gameObject.SetActive(true);
        _cartEditorPanel.gameObject.SetActive(false);
    }
}
