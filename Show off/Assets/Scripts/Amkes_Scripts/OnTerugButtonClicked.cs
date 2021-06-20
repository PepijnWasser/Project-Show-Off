using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTerugButtonClicked : MonoBehaviour
{
	[SerializeField] private Button terugButton;
	[SerializeField] private Canvas buildingPopup;
	private CamManager camManager;
	private bool isManagerFound;
	
	private void Start()
	{
		Button btn = terugButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

    private void Update()
    {
        if (isManagerFound != true)
        {
			if (GameObject.FindGameObjectWithTag("CamManager").GetComponent<CamManager>() != null)
            {
				camManager = GameObject.FindGameObjectWithTag("CamManager").GetComponent<CamManager>();
				isManagerFound = true;
			}
		}
    }

    void TaskOnClick()
	{
		if (buildingPopup.enabled == true)
        {
			buildingPopup.enabled = false;
        }

		if(isManagerFound == true)
        {
			camManager.ActiveCamera.SetActive(false);
			camManager.mainCam.SetActive(true);
			camManager.cameraControllerScript.enabled = true;
		}
	}
}
