using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public CameraController cameraControllerScript;
    public GameObject mainCam;
    public GameObject TaskboardCam;
    public GameObject ShopCam;
    public GameObject LabCam;
    public GameObject HarborCam;
    public GameObject CityHallCam;
    public GameObject HotelCam;
    public GameObject CowFarmCam;
    public GameObject BusStationCam;
    public GameObject CropFarmCam;
    public GameObject MerchFactoryCam;
    public GameObject CoralReefCam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //TODO: if hit.getcomponent<camera>...
                if (hit.transform.name == "TaakBord")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(TaskboardCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Winkel")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(ShopCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Lab")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(LabCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Haven")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(HarborCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Stadhuis")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(CityHallCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Hotel")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(HotelCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "CowFarm")
                {
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    CowFarmCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Busstation")
                {
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    BusStationCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "CropFarm")
                {
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    CropFarmCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "MerchFactory")
                {
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    MerchFactoryCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
            }
        }

        CheckEscapePressed(TaskboardCam);
        CheckEscapePressed(ShopCam);
        CheckEscapePressed(LabCam);
        CheckEscapePressed(HarborCam);
        CheckEscapePressed(CityHallCam);
        CheckEscapePressed(HotelCam);
        CheckEscapePressed(CowFarmCam);
        CheckEscapePressed(BusStationCam);
        CheckEscapePressed(CropFarmCam);
        CheckEscapePressed(MerchFactoryCam);
        CheckEscapePressed(CoralReefCam);
    }

    public void ActivateCamera(GameObject camera)
    {
        mainCam.SetActive(false);
        camera.SetActive(true);
    }

    public void DeActivateCamera(GameObject camera)
    {
        mainCam.SetActive(true);
        camera.SetActive(false);
    }

    private void CheckEscapePressed(GameObject camera)
    {
        if (camera.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                //Debug.Log("Escape-key pressed");
                camera.SetActive(false);
                mainCam.SetActive(true);
                cameraControllerScript.enabled = true;
            }
        }
    }
}
