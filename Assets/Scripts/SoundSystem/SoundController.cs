using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource sound;
    public AudioClip sounClip;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        sound.PlayOneShot(sounClip);
    }

    
}
