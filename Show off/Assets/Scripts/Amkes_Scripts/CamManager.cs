using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public CameraController cameraControllerScript;
    public GameObject ActiveCamera;
    public GameObject MainCam;
    public List<GameObject> publicCameras { get; private set; }

    [SerializeField] private Vector3 offset;
    [SerializeField] private List<GameObject> cameras = new List<GameObject>();
    private bool isCamerasPlaced;
    private GameObject buildingWithSameTag;

    private void Start()
    {
        isCamerasPlaced = false;
        publicCameras = cameras;
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
                //Search in cameras-list for camera with same tag as hit building
                for (int i = 0; i < cameras.Count; i++)
                {
                    if (cameras[i].tag == hit.transform.tag)
                    {
                        ActivateCamera(cameras[i]);

                        //If building has a menu attached, open it
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
        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].tag == "MainCamera" || cameras[i].tag == "CoralReef")
            {
                continue;
            }

            if (cameras[i].transform != null)
            {
                //Finding the object with same tag works, because function searches for active gameobjects
                //The camera is inactive and therefor the function will only find the building with the same tag
                buildingWithSameTag = GameObject.FindGameObjectWithTag(cameras[i].tag);
                if (buildingWithSameTag != null)
                {
                    Vector3 buildingPos = buildingWithSameTag.transform.position;
                    cameras[i].transform.position = buildingPos + offset;
                }
            }
            else
            {
                cameras[i].gameObject.SetActive(false);
            }
        }

        isCamerasPlaced = true;
    }
}
