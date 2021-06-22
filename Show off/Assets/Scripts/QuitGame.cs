using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitProgram()
    {
        Application.Quit();
        Debug.Log("Program Closed");
    }
}
