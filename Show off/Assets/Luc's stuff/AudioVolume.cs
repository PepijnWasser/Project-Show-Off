using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolume : MonoBehaviour
{

    public AudioMixer Mixer;
    public void SetLevel(float volume)
    {
        Mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
}




