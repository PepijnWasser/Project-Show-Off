using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundIsland : MonoBehaviour
{
    [SerializeField] private float keyboardSpeed = 50.0f;
    [SerializeField] private float mouseSpeed = 500.0f;
    private Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
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
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void UseKeyboardControls()
    {
        if (Input.GetKey(KeyCode.LeftShift))
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

    bool CheckValidYMovement()
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

    void MoveCamera()
    {
        transform.RotateAround(target, camTransform.right, -Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime);
    }
}
