using System;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    // string variables called keys
    private const string SelectedCharacterKey = "SelectedCharacter";
    private const string SteeringKey = "Steering";
    
    // property in C# same as set get methods for a variable
    public static int SelectedCharacter
    {
        // PlayerPrefs has float, int, string. other values should be created manual methods
        get => PlayerPrefs.GetInt(SelectedCharacterKey, 0);
        set
        {
            PlayerPrefs.SetInt(SelectedCharacterKey, value);
            OnDataChangeEvent();
        }
    }

    public static event EventHandler DataChangeEvent;
    private static void OnDataChangeEvent()
    {
        // sender is null since theres no 'this' in static environment
        DataChangeEvent?.Invoke(null, EventArgs.Empty);
    }
}
