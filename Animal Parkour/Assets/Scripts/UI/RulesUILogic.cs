using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RulesUILogic : MonoBehaviour
{
    private const string OkButtonName = "OK";
    private UIDocument _rulesUIDocument;
    
    public event EventHandler OkButtonPressed;

    private void OnEnable()
    {
        _rulesUIDocument = GetComponent<UIDocument>();
        
        // Resume
        _rulesUIDocument.rootVisualElement.Q<Button>(OkButtonName).clicked += () =>
        {
            Debug.Log("Resume with game");
            OnOkButtonPressedPressed();
        };
    }

    protected virtual void OnOkButtonPressedPressed()
    {
        OkButtonPressed?.Invoke(this, EventArgs.Empty);
    }
}
