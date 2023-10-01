using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerParkour : MonoBehaviour
{
    public AudioSource src;

    public AudioClip sfx1, sfx2, sfx3;
    private float energy;
    
    private void Start()
    {
        PersistentDataManager.EnergyChangeEvent += OnChangeEnergy;
    }

    private void OnChangeEnergy(object sender, EventArgs e)
    {
        // if (PersistentDataManager.GameHasStarted == 0) return;
        AudioClip audioClip;
        
        Debug.Log("energy " + energy);
        
        energy = PersistentDataManager.Energy;
        if (energy >= 10f)
        {
            audioClip = sfx3;
        } else if (energy <= 3)
        {
            audioClip = sfx2;
        }
        else
        {
            audioClip = sfx1;
        }

        if (src.clip == audioClip) return;
        src.clip = audioClip;
        src.Play();
    }
}
