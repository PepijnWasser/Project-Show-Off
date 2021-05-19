using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnCinematicFinish : MonoBehaviour
{
    public CinematicManager manager;
    public GameObject target;

    private void Update()
    {
        if (manager.finished)
        {
            target.SetActive(true);
        }
        else
        {
            target.SetActive(false);
        }
    }
}
