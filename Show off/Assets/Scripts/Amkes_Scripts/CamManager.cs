using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public CameraController cameraControllerScript;
    public GameObject mainCam;
    public GameObject CoralReefCam;

    public GameObject AnimalFarmCam;
    public GameObject BusStationCam;
    public GameObject CityHallCam;
    public GameObject CropFarmCam;
    public GameObject FactoryCam;
    public GameObject FisheryCam;
    public GameObject HarborCam;
    public GameObject HotelCam;
    public GameObject LabCam;
    public GameObject ShopCam;
    public GameObject TaskboardCam;

    public Vector3 offset;
    private bool isCamerasPlaced;

    private void Start()
    {
        isCamerasPlaced = false;
    }

    void Update()
    {
        if (isCamerasPlaced == false)
        {
            SetAllVirtualCameras();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
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
                if (hit.transform.name == "AnimalFarm")
                {
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    AnimalFarmCam.SetActive(true);

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
                if (hit.transform.name == "Factory")
                {
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    FactoryCam.SetActive(true);

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
        CheckEscapePressed(AnimalFarmCam);
        CheckEscapePressed(BusStationCam);
        CheckEscapePressed(CropFarmCam);
        CheckEscapePressed(FactoryCam);
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
                camera.SetActive(false);
                mainCam.SetActive(true);
                cameraControllerScript.enabled = true;
            }
        }
    }

    private void SetAllVirtualCameras()
    {
        SetVirtualCamera(AnimalFarmCam, "Animal Farm");
        SetVirtualCamera(BusStationCam, "BusStop");
        SetVirtualCamera(CityHallCam, "Stadhuis");
        SetVirtualCamera(CropFarmCam, "CropFarm");
        SetVirtualCamera(FactoryCam, "Fabriek");
        SetVirtualCamera(FisheryCam, "Fishery");
        SetVirtualCamera(HarborCam, "Haven");
        SetVirtualCamera(HotelCam, "Hotel");
        SetVirtualCamera(LabCam, "Lab");
        SetVirtualCamera(ShopCam, "Winkel");
        SetVirtualCamera(TaskboardCam, "TaakBord");

        isCamerasPlaced = true;
    }

    private void SetVirtualCamera(GameObject camera, string tagname)
    {
        if (camera != null)
        {
            Vector3 buildingPos = GameObject.FindGameObjectWithTag(tagname).transform.position;
            camera.transform.position = buildingPos + offset;
        }
    }
}
