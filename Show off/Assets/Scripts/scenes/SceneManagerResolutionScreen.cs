using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerResolutionScreen : MonoBehaviour
{
    public CinematicManager cinematicManager;

    private void Update()
    {
        if (cinematicManager.finished)
        {
            SceneManager.LoadScene("Credits"); //"EndScreen" before
        }
    }
}
