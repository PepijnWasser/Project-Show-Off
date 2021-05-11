using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnIsland : MonoBehaviour
{
    //[SerializeField] private float minFOV = 15.0f;
    //[SerializeField] private float maxFOV = 90.0f;
    [SerializeField] private float keysSensitivity = 7.5f;
    [SerializeField] private float mouseSensitivity = 50.0f;
    [SerializeField] float minDistance = 4.0f;
    [SerializeField] float maxDistance = 10.0f;
    private Vector3 targetPos = new Vector3(0, 0, 0);
    public Transform camPos;

    private void Update()
    {
        //UseKeyboardcontrolsFOV();
        //UseMouseControlsFOV();
        UseKeyboardcontrolsMovement();
        UseMouseControlsMovement();
    }

    /*
    private void UseKeyboardcontrolsFOV()
    {
        float fov = Camera.main.fieldOfView;

        //Zoom In
        if (Input.GetKey(KeyCode.Q)) fov -= 0.1f * keysSensitivity;
        //Zoom Out
        if (Input.GetKey(KeyCode.E)) fov -= -0.1f * keysSensitivity;

        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
    */
    
    /*
    private void UseMouseControlsFOV()
    {
        float fov = Camera.main.fieldOfView;

        //Zoom In or Out
        fov -= Input.GetAxis("Mouse ScrollWheel") * mouseSensitivity;

        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
    */

    private void UseKeyboardcontrolsMovement()
    {
        Vector3 dVec = targetPos - camPos.position;
        float distance = dVec.magnitude;

        if (Input.GetKey(KeyCode.Q))
        {
            //Zoom in
            if (distance > minDistance)
            {
                camPos.Translate(Vector3.forward * keysSensitivity * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            //Zoom out
            if (distance < maxDistance)
            {
                camPos.Translate(Vector3.forward * -keysSensitivity * Time.deltaTime);
            }
        }
    }

    private void UseMouseControlsMovement()
    {
        Vector3 dVec = targetPos - camPos.position;
        float distance = dVec.magnitude;

        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (distance > minDistance)
            {
                camPos.Translate(Vector3.forward * mouseSensitivity * Time.deltaTime);
            }
            else
            {
                //Place camera back to minDistance

            }
        }

        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (distance < maxDistance)
            {
                camPos.Translate(Vector3.forward * -mouseSensitivity * Time.deltaTime);
            }
            else
            {
                //Place camera back to maxDistance

            }
        }
    }
}
