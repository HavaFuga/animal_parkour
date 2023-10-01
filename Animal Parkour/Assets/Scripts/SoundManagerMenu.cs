using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMenu : MonoBehaviour
{
    public AudioSource src;

    public AudioClip sfx1;
    private float energy;
    
    private void Start()
    {
        src.PlayOneShot(sfx1);
    }
    
}
