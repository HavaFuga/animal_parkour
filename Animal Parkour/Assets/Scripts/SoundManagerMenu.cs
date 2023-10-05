using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMenu : MonoBehaviour
{
    public AudioSource src;

    public AudioClip homeMusic;
    private float energy;
    
    private void Start()
    {
        src.clip = homeMusic;
        src.Play();
    }
    
}
