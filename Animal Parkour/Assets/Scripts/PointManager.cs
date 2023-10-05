using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PointManager : MonoBehaviour
{
    public int points;
    private int _value;
    private string _pointsTagName = "Point";
    private string _trashTagName = "Trash";
    private OverlayUILogic _overlayPanel;
    private UIDocument _overlayDocument;
    public AudioSource src;
    public AudioClip PointCollectedSound;
    public AudioClip TrashCollectedSound;
    
    public static event EventHandler EnergyChanged;


    // Start is called before the first frame update
    void Start()
    {
        _value = 5;
        SetEnergy();
        PersistentDataManager.EnergyChangeEvent += OnChangeEnergy;
    }

    private void OnChangeEnergy(object sender, EventArgs e)
    {
        
    }

    private void SetEnergy()
    {
        PersistentDataManager.Energy = _value;
        OnEnergyChanged();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == _pointsTagName && _value < 10)
        {
            AddEnergy();
        } else if (collider.gameObject.tag == _trashTagName && _value > 0)
        {
            RemoveEnergy();
        }

        collider.gameObject.SetActive(false);
        SetEnergy();
    }

    private void AddEnergy()
    {
        float speed = PersistentDataManager.Speed;
        if (speed >= 10) return;

        PersistentDataManager.Speed = speed + 0.2f; 
        PersistentDataManager.LastCollected = PersistentDataManager.POINT_FRUIT;
        Debug.Log("Point collected");
        _value++;
    }

    private void RemoveEnergy()
    {
        float speed = PersistentDataManager.Speed;
        if (speed <= 0) return;

        PersistentDataManager.Speed = speed - 0.2f;
        PersistentDataManager.LastCollected = PersistentDataManager.POINT_TRASH;
        Debug.Log("Trash collected");
        _value--;
    }

    public virtual void OnEnergyChanged()
    {
        EnergyChanged?.Invoke(this, EventArgs.Empty);
    }
}
