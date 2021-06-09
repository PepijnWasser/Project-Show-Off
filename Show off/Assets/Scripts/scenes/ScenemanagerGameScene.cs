using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemanagerGameScene : MonoBehaviour
{
    public TimeScript time;
    public int numberOfDays;

    public delegate void DayChangingScene();
    public static event DayChangingScene onChangingScene;

    private void Update()
    {
        if(time.dayNumber >= numberOfDays)
        {
            onChangingScene?.Invoke();
            SceneManager.LoadScene("Resolution screen");
        }
    }
}
