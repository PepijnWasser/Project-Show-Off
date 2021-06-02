using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemanagerGameScene : MonoBehaviour
{
    public TimeScript time;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(time.dayNumber >= 8)
        {
            SceneManager.LoadScene("Resolution screen");
        }
    }
}
