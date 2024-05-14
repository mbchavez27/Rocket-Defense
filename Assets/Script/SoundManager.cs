using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip hit;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (MeteorController.hit)
        {
            MeteorController.hit = false;
            audioSource.PlayOneShot(hit);
        }

        if (!SoundController.soundon)
        {
            audioSource.enabled = false;
        }
    }

}
