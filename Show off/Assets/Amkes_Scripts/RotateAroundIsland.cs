using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundIsland : MonoBehaviour
{
    [SerializeField] private float keysSpeed = 50.0f;
    [SerializeField] private float mouseSpeed = 500.0f;
    private Vector3 islandOrigin = new Vector3(0.0f, 0.0f, 0.0f);
    private Camera cam;
    private Transform camTransform;

    float xAngle = 0.0f;
    [SerializeField] private float minAngle = 20.0f;
    [SerializeField] private float maxAngle = 60.0f;

    private void Start()
    {
        GetCameraTransform();
    }

    private void Update()
    {
        UseKeyboardControls();
        UseMouseControls();
    }

    private void GetCameraTransform()
    {
        cam = Camera.main;
        if (cam != null) camTransform = cam.transform;
    }

    private void UseKeyboardControls()
    {
        //Rotate around Y-axis (left-right)
        transform.RotateAround(islandOrigin, Vector3.up, -Input.GetAxis("Horizontal") * keysSpeed * Time.deltaTime);

        //Rotate around X-axis (up-down)
        xAngle = transform.eulerAngles.x;
        if (xAngle >= minAngle && xAngle <= maxAngle)
        {
            transform.RotateAround(islandOrigin, camTransform.right, Input.GetAxis("Vertical") * keysSpeed * Time.deltaTime);
        }
        else if (xAngle < minAngle && Input.GetAxisRaw("Vertical") == 1)
        {
            //Only move up
            transform.RotateAround(islandOrigin, camTransform.right, Input.GetAxis("Vertical") * keysSpeed * Time.deltaTime);
        }
        else if (xAngle > maxAngle && Input.GetAxisRaw("Vertical") == -1)
        {
            //Only move down
            transform.RotateAround(islandOrigin, camTransform.right, Input.GetAxis("Vertical") * keysSpeed * Time.deltaTime);
        }
    }

    private void UseMouseControls()
    {
        if (Input.GetMouseButton(0))
        {
            //Rotate around Y-axis (left-right)
            transform.RotateAround(islandOrigin, Vector3.up, Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime);

            //Rotate around X-axis (up-down)
            xAngle = transform.eulerAngles.x;
            if (xAngle >= minAngle && xAngle <= maxAngle)
            {
                transform.RotateAround(islandOrigin, camTransform.right, -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);
            }
            else if (xAngle < minAngle && Input.GetAxis("Mouse Y") < 0)
            {
                //Only move up
                transform.RotateAround(islandOrigin, camTransform.right, -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);
            }
            else if (xAngle > maxAngle && Input.GetAxis("Mouse Y") > 0)
            {
                //Only move down
                transform.RotateAround(islandOrigin, camTransform.right, -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);
            }
        }
    }
}
