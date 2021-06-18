using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTerugButtonClicked : MonoBehaviour
{
	public Button terugButton;
	public GameObject virtualCameras;

	private List<Transform> camerasList = new List<Transform>();

	void Start()
	{
		foreach (Transform child in virtualCameras.transform)
        {
			camerasList.Add(child);
        }

		Button btn = terugButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		for (int i = 0; i < camerasList.Count; i++)
        {
			if (camerasList[i].tag == "MainCamera")
            {
				camerasList[i].gameObject.SetActive(true);
			}
			camerasList[i].gameObject.SetActive(false);
        }
	}
}
