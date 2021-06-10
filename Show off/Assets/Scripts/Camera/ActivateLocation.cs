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
        if (this.name == "Winkel")
        {
            manager.ActivateCamera(manager.ShopCam);
            GameObject.FindGameObjectWithTag("Shop").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Hotel")
        {
            manager.ActivateCamera(manager.HotelCam);
            GameObject.FindGameObjectWithTag("Hotel").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "TaakBord")
        {
            manager.ActivateCamera(manager.TaskboardCam);
            GameObject.FindGameObjectWithTag("QuestBoard").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Haven")
        {
            manager.ActivateCamera(manager.HarborCam);
            GameObject.FindGameObjectWithTag("Harbor").GetComponent<Building>().showMenu = true;
        }
        else if (this.name == "Stadhuis")
        {
            manager.ActivateCamera(manager.CityHallCam);
            GameObject.FindGameObjectWithTag("CityHall").GetComponent<Building>().showMenu = true;
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