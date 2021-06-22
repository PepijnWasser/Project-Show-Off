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
            manager.ActivateCamera(manager.ShopCam);
            GameObject.FindGameObjectWithTag("Winkel").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Hotel")
        {
            manager.ActivateCamera(manager.HotelCam);
            GameObject.FindGameObjectWithTag("Hotel").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "TaakBord")
        {
            manager.ActivateCamera(manager.TaskboardCam);
            GameObject.FindGameObjectWithTag("TaakBord").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Haven")
        {
            manager.ActivateCamera(manager.HarborCam);
            GameObject.FindGameObjectWithTag("Haven").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Stadhuis")
        {
            manager.ActivateCamera(manager.CityHallCam);
            GameObject.FindGameObjectWithTag("Stadhuis").GetComponent<Building>().showMenu = true;
        }
        else if(this.name == "Lab")
        {
            manager.ActivateCamera(manager.LabCam);
            GameObject.FindGameObjectWithTag("Lab").GetComponent<Building>().showMenu = true;
        }
        else
        {
            Debug.Log(this.name);
        }
    }
}
