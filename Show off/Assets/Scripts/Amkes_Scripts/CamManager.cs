using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public CameraController cameraControllerScript;
    public GameObject ActiveCamera;
    public GameObject MainCam;
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

    [SerializeField] private Vector3 offset;
    [SerializeField] private List<GameObject> cameras = new List<GameObject>();
    private bool isCamerasPlaced;

    private void Start()
    {
        isCamerasPlaced = false;
    }

    private void Update()
    {
        //Set up all cameras
        if (isCamerasPlaced == false)
        {
            SetAllVirtualCameras();
        }

        //Zoom to clicked building (activate building-camera/deactivate main-camera)
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < cameras.Count; i++)
                {
                    if (cameras[i].tag == hit.transform.tag)
                    {
                        ActivateCamera(cameras[i]);

                        if (cameras[i].GetComponent<Building>() != null)
                        {
                            cameras[i].GetComponent<Building>().showMenu = true;
                        }
                    }
                }
            }
        }

        //Check if a camera is activate and escape is pressed to deactivate building-camera/activate main-camera
        for (int i = 0; i < cameras.Count; i++)
        {
            CheckEscapePressed(cameras[i]);
        }
    }

    public void ActivateCamera(GameObject camera)
    {
        ActiveCamera = camera;

        //Set all cameras inactive, except clicked building-camera
        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].gameObject == camera.gameObject)
            {
                continue;
            }

            cameras[i].gameObject.SetActive(false);
        }

        camera.SetActive(true);

        if(camera == MainCam)
        {
            cameraControllerScript.enabled = true;
        }
        else
        {
            //Disable movement when zoomed on building
            cameraControllerScript.enabled = false;
        }
    }

    public void DeActivateCamera(GameObject camera)
    {
        //Deactivate building-camera/activate main camera
        camera.SetActive(false);
        MainCam.SetActive(true);

        //Enable movement again when zooming back to main-camera
        cameraControllerScript.enabled = true;
    }

    private void CheckEscapePressed(GameObject camera)
    {
        if (camera.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                DeActivateCamera(camera);
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
        //Set up a camera in front of the building
        if (camera.transform != null)
        {
            if (GameObject.FindGameObjectWithTag(tagname) != null)
            {
                Vector3 buildingPos = GameObject.FindGameObjectWithTag(tagname).transform.position;
                camera.transform.position = buildingPos + offset;
            }
            else
            {
                camera.gameObject.SetActive(false);
            }
        }
    }
}
