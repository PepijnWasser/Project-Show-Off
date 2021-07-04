using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OnVideoEnd : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject startCinematics;
    [SerializeField] private GameObject controlsUI;
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
