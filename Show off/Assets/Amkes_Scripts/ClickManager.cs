using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
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

    private void Update()
    {
        if (DoubleClick())
        {
            Debug.Log("Double-click detected");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Taskboard")
                {
                    Debug.Log("Clicked on Taskboard");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    TaskboardCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Shop")
                {
                    Debug.Log("Clicked on Shop");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    ShopCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Lab")
                {
                    Debug.Log("Clicked on Lab");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    LabCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Harbor")
                {
                    Debug.Log("Clicked on Harbor");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    HarborCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "CityHall")
                {
                    Debug.Log("Clicked on City Hall");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    CityHallCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Hotel")
                {
                    Debug.Log("Clicked on Hotel");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    HotelCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "CowFarm")
                {
                    Debug.Log("Clicked on Cow Farm");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    CowFarmCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "Busstation")
                {
                    Debug.Log("Clicked on Bus Station");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    BusStationCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "CropFarm")
                {
                    Debug.Log("Clicked on Crop Farm");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    CropFarmCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
                if (hit.transform.name == "MerchFactory")
                {
                    Debug.Log("Clicked on Merch Factory");
                    //Set Taskboard-cam active
                    mainCam.SetActive(false);
                    MerchFactoryCam.SetActive(true);

                    //Disable camera control
                    cameraControllerScript.enabled = false;
                }
            }
        }

        SetCamInactive(TaskboardCam);
        SetCamInactive(ShopCam);
        SetCamInactive(LabCam);
        SetCamInactive(HarborCam);
        SetCamInactive(CityHallCam);
        SetCamInactive(HotelCam);
        SetCamInactive(CowFarmCam);
        SetCamInactive(BusStationCam);
        SetCamInactive(CropFarmCam);
        SetCamInactive(MerchFactoryCam);
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

    private void SetCamInactive(GameObject camera)
    {
        if (camera.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("Escape-key pressed");
                camera.SetActive(false);
                mainCam.SetActive(true);
                cameraControllerScript.enabled = true;
            }
        }
    }
}
