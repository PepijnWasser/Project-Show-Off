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
        if (this.name == "Shop")
        {
            manager.ActivateCamera(manager.ShopCam);
        }
        else if (this.name == "Hotel")
        {
            manager.ActivateCamera(manager.HotelCam);
        }
        else if (this.name == "QuestBoard")
        {
            manager.ActivateCamera(manager.TaskboardCam);
        }
        else if (this.name == "Harbor")
        {
            manager.ActivateCamera(manager.HarborCam);
        }
        else if (this.name == "CityHall")
        {
            manager.ActivateCamera(manager.CityHallCam);
        }
        else if(this.name == "Lab")
        {
            manager.ActivateCamera(manager.LabCam);
        }
        else
        {
            Debug.Log(this.name);
        }
    }
}
