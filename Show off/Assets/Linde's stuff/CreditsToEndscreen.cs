using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToEndscreen : MonoBehaviour
{
    public void LoadEnd()
    {
        SceneManager.LoadScene("EndScreen");
    }
}

