using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAudio : MonoBehaviour
{
    [SerializeField] private GameObject audioManager;
    [SerializeField] private GameObject startCinematics;

    private void Update()
    {
        if (startCinematics.activeInHierarchy == true)
        {
            audioManager.SetActive(false);
        }
        else if (startCinematics.activeInHierarchy == false)
        {
            audioManager.SetActive(true);
        }
    }
}
