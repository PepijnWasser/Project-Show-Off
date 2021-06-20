using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTerugButtonClicked : MonoBehaviour
{
	[SerializeField] private Button terugButton;
	[SerializeField] private Canvas buildingPopup;
	private CamManager camManagerScript;
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
				camManagerScript = GameObject.FindGameObjectWithTag("CamManager").GetComponent<CamManager>();
				isManagerFound = true;
			}
		}
    }

    private void TaskOnClick()
	{
		//Close the building pop-up
		if (buildingPopup.enabled == true)
        {
			buildingPopup.enabled = false;
        }

		//Deactivate the building-camera/activate the main camera + enable movement again
		if(isManagerFound == true)
        {
			camManagerScript.ActiveCamera.SetActive(false);
			camManagerScript.MainCam.SetActive(true);
			camManagerScript.cameraControllerScript.enabled = true;
		}
	}
}
