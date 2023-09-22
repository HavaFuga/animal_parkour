using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class OverlayUILogic : MonoBehaviour
    {
        private const string PauseMenuButtonName = "Pause";

        public event EventHandler PauseMenuButtonPressed;

        protected virtual void OnPauseMenuButtonPressed()
        {
            PauseMenuButtonPressed?.Invoke(this, EventArgs.Empty);
        }
        
        private UIDocument _overlayDocument;

        private void OnEnable()
        {
            _overlayDocument = GetComponent<UIDocument>();

            _overlayDocument.rootVisualElement.Q<Button>(PauseMenuButtonName).clicked += () =>
            {
                Debug.Log("Pause Menu Button Pressed");
                OnPauseMenuButtonPressed();
            };
        }
    }
}