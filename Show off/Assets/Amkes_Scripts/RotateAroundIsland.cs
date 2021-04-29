using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundIsland : MonoBehaviour
{
    [SerializeField] private float speed = 50.0f;
    private GameObject island;
    private Transform islandTransform;
    private Camera cam;
    private Transform camTransform;

    private void Start()
    {
        GetIslandTransform();
        GetCameraTransform();
    }

    private void Update()
    {
        UseKeyboardControls();
        //UseMouseControls();
    }

    private void GetIslandTransform()
    {
        island = GameObject.Find("Island");
        if (island != null) islandTransform = island.transform;
    }

    private void GetCameraTransform()
    {
        cam = Camera.main;
        if (cam != null) camTransform = cam.transform;
    }

    private void UseKeyboardControls()
    {
        //Rotate around Y-axis (left-right)
        transform.RotateAround(islandTransform.position, Vector3.up, -Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //Rotate around X-axis (up-down)
        transform.RotateAround(islandTransform.position, camTransform.right, Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }

    private void UseMouseControls()
    {
        //TODO: Use mouse-controls
    }
}
