using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnIsland : MonoBehaviour
{
    [SerializeField] private float minFOV = 15.0f;
    [SerializeField] private float maxFOV = 90.0f;
    [SerializeField] private float keysSensitivity = 0.5f;
    [SerializeField] private float mouseSensitivity = 20.0f;

    private void Update()
    {
        UseMouseControlsFOV();
        //UseMouseControlsMovement();
        UseKeyboardcontrols();
    }

    private void UseKeyboardcontrols()
    {
        float fov = Camera.main.fieldOfView;

        //Zoom In
        if (Input.GetKey(KeyCode.Q)) fov -= 0.1f * keysSensitivity;
        //Zoom Out
        if (Input.GetKey(KeyCode.E)) fov -= -0.1f * keysSensitivity;

        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
    
    private void UseMouseControlsFOV()
    {
        float fov = Camera.main.fieldOfView;

        //Zoom In or Out
        fov -= Input.GetAxis("Mouse ScrollWheel") * mouseSensitivity;

        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }

    private void UseMouseControlsMovement()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z + 0.3f);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z - 0.3f);
        }
    }
}
