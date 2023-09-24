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
    
    public static event EventHandler EnergyChanged;

    // Start is called before the first frame update
    void Start()
    {
        _value = 5;
        SetEnergy();
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
            Debug.Log("Point collected");
            _value++;
        } else if (collider.gameObject.tag == _trashTagName && _value > 0)
        {
            Debug.Log("Trash collected");
            _value--;
        }

        collider.gameObject.SetActive(false);
        SetEnergy();
    }

    public virtual void OnEnergyChanged()
    {
        EnergyChanged?.Invoke(this, EventArgs.Empty);
    }
}
