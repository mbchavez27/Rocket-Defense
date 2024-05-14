using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    public static bool soundon;
    public Toggle soundIcon;

    void Start()
    {
        soundon = true;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(soundon) {
            audioSource.enabled = true;
            soundIcon.isOn = false;
        }
        else if(!soundon)
        {
            audioSource.enabled = false;
            soundIcon.isOn = true;
        }
    }

    public void ChangeSound()
    {
        if (soundon)
        {
            soundon = false;
        }
        else if(!soundon)
        {
            soundon = true;
        }
    }
}
