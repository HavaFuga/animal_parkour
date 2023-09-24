using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class OverlayUILogic : MonoBehaviour
    {
        private const string PauseMenuButtonName = "Pause";
        private const string TimerLabelName = "Timer";

        public event EventHandler PauseMenuButtonPressed;

        private void Awake()
        {
            PointManager.EnergyChanged += AdjustEnergy;
        }

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

        private void Update()
        {
            if (Time.timeScale != 0f)
            {
                UpdateTimer();
            }
        }

        private void UpdateTimer()
        {
            int min = (int)(Time.timeSinceLevelLoad / 60);
            int sec = (int)(Time.timeSinceLevelLoad % 60);
            string time = min + ":" + sec;
            _overlayDocument.rootVisualElement.Q<Label>(TimerLabelName).text = time;
        }

        private void AdjustEnergy(object sender, EventArgs e)
        {
            SetEnergy();
        }

        private void SetEnergy()
        {
            _overlayDocument.rootVisualElement.Q<ProgressBar>(PersistentDataManager.EnergyBarName).value = PersistentDataManager.Energy * 10;
        }
        
    }
}