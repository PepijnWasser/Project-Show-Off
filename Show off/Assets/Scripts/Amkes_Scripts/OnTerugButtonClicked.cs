using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTerugButtonClicked : MonoBehaviour
{
	public Button terugButton;
	public Canvas buildingPopup;
	
	void Start()
	{
		Button btn = terugButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		if (buildingPopup.enabled == true)
        {
			buildingPopup.enabled = false;
        }
	}
}
