using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OnVideoEnd : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject startCinematics;
    public GameObject controlsUI;
    [SerializeField] private GameObject audioManager;

    private void Update()
    {
        if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
        {
            startCinematics.SetActive(false);
            controlsUI.SetActive(true);
            audioManager.SetActive(true);
        }
    }
}
