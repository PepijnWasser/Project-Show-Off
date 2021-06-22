using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAudio : MonoBehaviour
{
    GameObject audioManager;
    AudioSource audioToPlay;
    public string NameOfObjectToBeFound;
    void Start()
    {
        audioManager = GameObject.Find(NameOfObjectToBeFound);
        audioToPlay = audioManager.GetComponent<AudioSource>();
    }
    public void playAudio()
    {
        audioToPlay.Play();
    }
}
