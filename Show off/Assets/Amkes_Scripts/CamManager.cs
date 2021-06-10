using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    private float clicked = 0.0f;
    private float clickTime = 0.0f;
    private float clickDelay = 0.5f;

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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Taskboard")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(TaskboardCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Shop")
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
                if (hit.transform.name == "Harbor")
                {
                    //Set Taskboard-cam active
                    ActivateCamera(HarborCam);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "CityHall")
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
    }


    private bool DoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1.0f)
            {
                clickTime = Time.time;
            }

        }

        if (clicked > 1 && Time.time - clickTime < clickDelay)
        {
            clicked = 0.0f;
            clickTime = 0.0f;
            return true;
        }
        else if (clicked > 2 || Time.time - clickTime > 1)
        {
            clicked = 0.0f;
        }

        return false;
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
