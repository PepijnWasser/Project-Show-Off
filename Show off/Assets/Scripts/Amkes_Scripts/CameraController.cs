using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float minXRot;
    [SerializeField] private float maxXrot;
    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;
    [SerializeField] private GameObject camObject;
    [SerializeField] private float minXBound;
    [SerializeField] private float maxXBound;
    [SerializeField] private float minZBound;
    [SerializeField] private float maxZBound;
    [SerializeField] private CinemachineVirtualCamera mainCam;
    private KeyCode rotateLeft = KeyCode.Q;
    private KeyCode rotateRight = KeyCode.E;

    private void Update()
    {
        //Zooming
        ZoomingMouse();         //Scrollwheel

        //Rotating
        RotatingMouse();        //Right-MB + Drag
        RotatingKeys();         //Q+E keys

        //Moving
        MovingKeys();           //WASD- or Arrow-keys
    }

    private void ZoomingMouse()
    {
        //Zoom in or out (changing FOV)
        mainCam.m_Lens.FieldOfView += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        //Make sure player doesn't zoom in or out too much
        mainCam.m_Lens.FieldOfView = Mathf.Clamp(mainCam.m_Lens.FieldOfView, minFOV, maxFOV);
    }

    private void RotatingMouse()
    {
        //Right-MB + Drag
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxisRaw("Mouse X");
            SetRotation(x);
        }
    }

    private void RotatingKeys()
    {
        //Q+E keys
        if (Input.GetKey(rotateLeft))
        {
            //Left
            SetRotation(-1);
        }
        if (Input.GetKey(rotateRight))
        {
            //Right
            SetRotation(1);
        }
    }

    private void SetRotation(float rotationDir)
    {
        //Rotate around y-axis (left/right)
        transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y + (rotationDir * rotateSpeed), 0.0f);
    }

    private void MovingKeys()
    {
        //WASD- or Arrow-keys
        Vector3 forward = mainCam.transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        Vector3 right = mainCam.transform.right.normalized;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = forward * moveZ + right * moveX;
        dir.Normalize();
        dir *= moveSpeed * Time.deltaTime;
        transform.position += dir;

        //Make sure player stays within the playing-field
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXBound, maxXBound), transform.position.y, Mathf.Clamp(transform.position.z, minZBound, maxFOV));
    }
}
