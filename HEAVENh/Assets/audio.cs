using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Play the audio when the game starts
        audioSource.Play();
    }
}

    