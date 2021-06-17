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
    [SerializeField] private List<GameObject> cameras = new List<GameObject>();

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
                    ActivateCamera(TaskboardCam);
                }
                if (hit.transform.name == "Winkel")
                {
                    ActivateCamera(ShopCam);
                }
                if (hit.transform.name == "Lab")
                {
                    ActivateCamera(LabCam);
                }
                if (hit.transform.name == "Haven")
                {
                    ActivateCamera(HarborCam);
                }
                if (hit.transform.name == "Stadhuis")
                {
                    ActivateCamera(CityHallCam);
                }
                if (hit.transform.name == "Hotel")
                {
                    ActivateCamera(HotelCam);
                }
                if (hit.transform.name == "AnimalFarm")
                {
                    ActivateCamera(AnimalFarmCam);
                }
                if (hit.transform.name == "Busstation")
                {
                    ActivateCamera(BusStationCam);
                }
                if (hit.transform.name == "CropFarm")
                {
                    ActivateCamera(CropFarmCam);
                }
                if (hit.transform.name == "Factory")
                {
                    ActivateCamera(FactoryCam);
                }
                if (hit.transform.name == "Fishery")
                {
                    ActivateCamera(FisheryCam);
                }
            }
        }

        for (int i = 0; i < cameras.Count; i++)
        {
            CheckEscapePressed(cameras[i]);
        }
    }

    public void ActivateCamera(GameObject camera)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].gameObject == camera.gameObject)
            {
                continue;
            }

            cameras[i].gameObject.SetActive(false);
        }

        camera.SetActive(true);

        cameraControllerScript.enabled = false;
    }

    public void DeActivateCamera(GameObject camera)
    {
        camera.SetActive(false);
        mainCam.SetActive(true);

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
        if (camera != null)
        {
            Vector3 buildingPos = GameObject.FindGameObjectWithTag(tagname).transform.position;
            camera.transform.position = buildingPos + offset;
        }
    }
}
