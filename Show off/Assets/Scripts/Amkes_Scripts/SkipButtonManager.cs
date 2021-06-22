using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipButtonManager : MonoBehaviour
{
    public Image skipButtonImage;
    public GameObject controlsUI;
    public GameObject startCinematics;
    public CameraController cameraControllerScript;

    private Color skipButtoncolorVisible;
    private Color skipButtoncolorTransparent;

    private void Awake()
    {
        skipButtoncolorVisible = skipButtonImage.color;
        skipButtoncolorTransparent = new Vector4(skipButtoncolorVisible.r, skipButtoncolorVisible.g, skipButtoncolorVisible.b, 0.5f);

        skipButtonImage.color = skipButtoncolorTransparent;

        cameraControllerScript.enabled = false;
    }

    public void StartGame()
    {
        startCinematics.SetActive(false);
        controlsUI.SetActive(true);
    }

    public void SetFullyVisible()
    { 
        skipButtonImage.color = skipButtoncolorVisible;
    }

    public void SetHalfVisible()
    {
        skipButtonImage.color = skipButtoncolorTransparent;
    }
}
