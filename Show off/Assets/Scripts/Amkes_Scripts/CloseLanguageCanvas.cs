using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseLanguageCanvas : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject languageCanvas;

    public void CloseCanvas()
    {
        startCanvas.SetActive(true);
        languageCanvas.SetActive(false);
    }
}
