using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnClick : MonoBehaviour
{
    public bool BigRedButton;

    private void Update()
    {
        if (BigRedButton)
        {
            SceneManager.LoadScene("Credits"); //"EndScreen" before
        }
    }

}
