using System;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    // string variables called keys
    private const string SelectedCharacterKey = "SelectedCharacter";
    private const string EnergyKey = "Energy";
    private const string LastCollectedKey = "LastCollected";
    private const string SpeedKey = "Speed";
    private const string GameHasStartedKey = "Speed";
    public static readonly string EnergyBarName = "Energy";
    
    // Point States
    public const string POINT_FRUIT = "Fruit";
    public const string POINT_TRASH = "Trash";
    
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
    public const string PLAYER_FEAR = "Fear";
    public const string PLAYER_BOUNCE = "Bounce";
    
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
        get => PlayerPrefs.GetInt(EnergyKey, 5);
        set
        {
            PlayerPrefs.SetInt(EnergyKey, value);
            OnEnergyChangeEvent();
        }
    }
    
    public static string LastCollected
    {
        // PlayerPrefs has float, int, string. other values should be created manual methods
        get => PlayerPrefs.GetString(EnergyKey, "");
        set
        {
            PlayerPrefs.SetString(EnergyKey, value);
            OnEnergyChangeEvent();
        }
    }

    public static float Speed
    {
        get => PlayerPrefs.GetFloat(SpeedKey, 4.0f);
        set
        {
            PlayerPrefs.SetFloat(SpeedKey, value);
            OnSpeedChangeEvent();
        }
        
    }
    
    public static int GameHasStarted
    {
        get => PlayerPrefs.GetInt(GameHasStartedKey, 0);
        set => PlayerPrefs.SetInt(GameHasStartedKey, value);
        
    }
    
    public static event EventHandler DataChangeEvent;
    private static void OnDataChangeEvent()
    {
        // sender is null since theres no 'this' in static environment
        DataChangeEvent?.Invoke(null, EventArgs.Empty);
    }

    public static event EventHandler EnergyChangeEvent;
    private static void OnEnergyChangeEvent()
    {
        // sender is null since theres no 'this' in static environment
        EnergyChangeEvent?.Invoke(null, EventArgs.Empty);
    }
    public static event EventHandler SpeedChangeEvent;
    private static void OnSpeedChangeEvent()
    {
        // sender is null since theres no 'this' in static environment
        SpeedChangeEvent?.Invoke(null, EventArgs.Empty);
    }
}
