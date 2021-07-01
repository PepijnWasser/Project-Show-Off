using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSettingsButtonClicked : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settingsPanelImage;
    private bool isImageOn;

    private void Start()
    {
        settingsPanelImage.SetActive(false);
        isImageOn = false;

        Button btn = settingsButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (isImageOn == false)
        {
            settingsPanelImage.SetActive(true);
            isImageOn = true;
        }
        else
        {
            settingsPanelImage.SetActive(false);
            isImageOn = false;
        }
    }
}
