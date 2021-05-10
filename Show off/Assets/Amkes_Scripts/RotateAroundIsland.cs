using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundIsland : MonoBehaviour
{
    [SerializeField] private float keysSpeed = 50.0f;
    [SerializeField] private float mouseSpeed = 500.0f;
    //private GameObject island;
    //private Transform islandTransform;
    private Vector3 islandOrigin = new Vector3(0.0f, 0.0f, 0.0f);
    private Camera cam;
    private Transform camTransform;

    private void Start()
    {
        //GetIslandTransform();
        GetCameraTransform();
    }

    private void Update()
    {
        UseKeyboardControls();
        //UseMouseControls();
    }

    /*
    private void GetIslandTransform()
    {
        island = GameObject.Find("Island");
        if (island != null) islandTransform = island.transform;
    }
    */

    private void GetCameraTransform()
    {
        cam = Camera.main;
        if (cam != null) camTransform = cam.transform;
    }

    private void UseKeyboardControls()
    {
        //Rotate around Y-axis (left-right)
        //transform.RotateAround(islandTransform.position, Vector3.up, -Input.GetAxis("Horizontal") * keysSpeed * Time.deltaTime);
        transform.RotateAround(islandOrigin, Vector3.up, -Input.GetAxis("Horizontal") * keysSpeed * Time.deltaTime);
        //Rotate around X-axis (up-down)
        //transform.RotateAround(islandTransform.position, camTransform.right, Input.GetAxis("Vertical") * keysSpeed * Time.deltaTime);
        transform.RotateAround(islandOrigin, camTransform.right, Input.GetAxis("Vertical") * keysSpeed * Time.deltaTime);
    }

    private void UseMouseControls()
    {
        if (Input.GetMouseButton(0))
        {
            //Rotate around Y-axis (left-right)
            //transform.RotateAround(islandTransform.position, Vector3.up, Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime);
            transform.RotateAround(islandOrigin, Vector3.up, Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime);
            //Rotate around X-axis (up-down)
            //transform.RotateAround(islandTransform.position, camTransform.right, -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);
            transform.RotateAround(islandOrigin, camTransform.right, -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);
        }
    }
}
