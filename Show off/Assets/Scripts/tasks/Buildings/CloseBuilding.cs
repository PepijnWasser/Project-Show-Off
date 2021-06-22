using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBuilding : MonoBehaviour
{
    public GameObject building;

    public void DisablePanel()
    {
        building.GetComponent<Building>().showMenu = false;
        CamManager manager = GameObject.FindObjectOfType<CamManager>();
        manager.ActivateCamera(manager.MainCam);
    }
}
