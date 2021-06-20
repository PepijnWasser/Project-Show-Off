//UNUSED SCRIPT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundIsland : MonoBehaviour
{
    [SerializeField] private float keyboardSpeed;
    [SerializeField] private float mouseSpeed;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    private Vector3 target = new Vector3(0,0,0);
    private Transform camTransform;
    private float xAngle = 0.0f;
    private KeyCode enableRotation = KeyCode.LeftShift;
    
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
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void UseKeyboardControls()
    {
        if (Input.GetKey(enableRotation))
        {
            //Rotate around Y-axis (left-right)
            transform.RotateAround(target, Vector3.up, -Input.GetAxis("Horizontal") * keyboardSpeed * Time.deltaTime);

            //Rotate around X-axis (up-down)
            xAngle = transform.eulerAngles.x;
            if (xAngle >= minAngle && xAngle <= maxAngle)
            {
                transform.RotateAround(target, camTransform.right, Input.GetAxis("Vertical") * keyboardSpeed * Time.deltaTime);
            }
            else if (xAngle < minAngle && Input.GetAxisRaw("Vertical") == 1)
            {
                //Only move up
                transform.RotateAround(target, camTransform.right, Input.GetAxis("Vertical") * keyboardSpeed * Time.deltaTime);
            }
            else if (xAngle > maxAngle && Input.GetAxisRaw("Vertical") == -1)
            {
                //Only move down
                transform.RotateAround(target, camTransform.right, Input.GetAxis("Vertical") * keyboardSpeed * Time.deltaTime);
            }
        }
    }

    private void UseMouseControls()
    {
        if (Input.GetMouseButton(0))
        {
            //Rotate around Y-axis (left-right)
            transform.RotateAround(target, Vector3.up, Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime);

            //Rotate around X-axis (up-down)
            xAngle = transform.eulerAngles.x;
            if (CheckValidYMovement())
            {
                MoveCamera();
            }
        }
    }

    private bool CheckValidYMovement()
    {
        bool withinBorders = xAngle >= minAngle && xAngle <= maxAngle;
        bool movingUpAllowed = xAngle < minAngle && Input.GetAxis("Mouse Y") < 0;
        bool movingDownAllowed = xAngle > maxAngle && Input.GetAxis("Mouse Y") > 0;

        if (withinBorders || movingUpAllowed || movingDownAllowed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveCamera()
    {
        transform.RotateAround(target, camTransform.right, -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);
    }
}
