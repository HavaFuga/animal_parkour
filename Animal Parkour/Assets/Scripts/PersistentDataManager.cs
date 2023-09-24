using System;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    // string variables called keys
    private const string SelectedCharacterKey = "SelectedCharacter";
    private const string EnergyKey = "Energy";
    public static readonly string EnergyBarName = "Energy";
    
    // Animation States
    public const string PLAYER_IDLE = "Idle_A";
    public const string PLAYER_WALK = "Walk";
    public const string PLAYER_RUN = "Run";
    public const string PLAYER_FLY = "Fly";
    public const string PLAYER_SWIM = "Swim";
    public const string PLAYER_DEATH = "Death";
    public const string PLAYER_JUMP = "Jump";
    public const string PLAYER_SPIN = "Spin";
    public const string PLAYER_ROLL = "Roll";
    
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
    
    // property in C# same as set get methods for a variable
    public static int Energy
    {
        // PlayerPrefs has float, int, string. other values should be created manual methods
        get => PlayerPrefs.GetInt(EnergyKey, 0);
        set
        {
            PlayerPrefs.SetInt(EnergyKey, value);
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
