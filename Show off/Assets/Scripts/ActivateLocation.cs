using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateLocation : MonoBehaviour, IPointerClickHandler
{
    CamManager manager;

    private void Start()
    {
        manager = GameObject.FindObjectOfType(typeof(CamManager)) as CamManager;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("TaskList").gameObject.SetActive(false);

        if (this.name == "Winkel")
        {
            manager.ActivateCamera(FindCameraWithTag(this.name));
            GameObject.FindGameObjectWithTag("Winkel").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Hotel")
        {
            manager.ActivateCamera(FindCameraWithTag(this.name));
            GameObject.FindGameObjectWithTag("Hotel").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "TaakBord")
        {
            manager.ActivateCamera(FindCameraWithTag(this.name));
            GameObject.FindGameObjectWithTag("TaakBord").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Haven")
        {
            manager.ActivateCamera(FindCameraWithTag(this.name));
            GameObject.FindGameObjectWithTag("Haven").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Stadhuis")
        {
            manager.ActivateCamera(FindCameraWithTag(this.name));
            GameObject.FindGameObjectWithTag("Stadhuis").GetComponent<Building>().showMenu = true;
        }
        else if(this.name == "Lab")
        {
            manager.ActivateCamera(FindCameraWithTag(this.name));
            GameObject.FindGameObjectWithTag("Lab").GetComponent<Building>().showMenu = true;
        }
        else
        {
            Debug.Log(this.name);
        }
    }

    private GameObject FindCameraWithTag(string pName)
    {
        GameObject chosenCam = null;

        for (int i = 0; i < manager.publicCameras.Count; i++)
        {
            if (pName == manager.publicCameras[i].tag)
            {
                chosenCam = manager.publicCameras[i];
            }
        }

        return chosenCam;
    }
}
