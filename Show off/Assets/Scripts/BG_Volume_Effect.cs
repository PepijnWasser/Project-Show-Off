using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Volume_Effect : MonoBehaviour
{
    public List<GameObject> Cam;
    public List<AudioSource> Music;
    List <bool> playAudio = new List<bool>();
    private void Start()
    {
        for (int i = 0; i < Cam.Count; i++)
        {
            bool sdf = false;
            playAudio.Add(sdf);
        }
    }
    void Update()
    {
        for (int i = 0; i < Cam.Count; i++ ) { 
        if (Cam[i].activeInHierarchy)
        {
            if (playAudio[i] == false) {
                Music[i].volume = 0.1f;
                playAudio[i] = true;
            }
        } else
        {
            Music[i].volume = 0.03f;
            playAudio[i] = false;
        }
    }
    }
}