using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float minXRot;
    public float maxXrot;
    public float minZoom;
    public float maxZoom;
    public float zoomSpeed;
    public float rotateSpeed;
    public GameObject camObject;

    private float curXRot;
    private float curZoom;
    private Camera cam;
    private KeyCode zoomInKey = KeyCode.Q;
    private KeyCode zoomOutKey = KeyCode.E;
    private KeyCode accesRotationKey = KeyCode.LeftShift;

    private void Start()
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXRot = camObject.transform.rotation.x;
    }

    private void Update()
    {
        //Zooming
        ZoomingMouse();
        ZoomingKeys();

        //Rotating
        RotatingMouse();
        RotatingKeys();

        //Moving
        MovingMouse();
        MovingKeys();
    }

    private void ZoomingMouse()
    {
        //Scrollwheel to zoom
        curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);
        cam.transform.localPosition = Vector3.up * curZoom;
    }

    private void ZoomingKeys()
    {
        //Q -> zoom in, E -> zoom out
        if (Input.GetKey(zoomInKey))
        {
            curZoom += 0.01f * -zoomSpeed;
        }
        if (Input.GetKey(zoomOutKey))
        {
            curZoom += -0.01f * -zoomSpeed;
        }
        
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);
        cam.transform.localPosition = Vector3.up * curZoom;
    }

    private void RotatingMouse()
    {
        //Left-MB + drag to rotate
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            curXRot += -y * rotateSpeed;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXrot);
            transform.eulerAngles = new Vector3(curXRot, transform.eulerAngles.y + (x * rotateSpeed), 0.0f);
        }
    }

    private void RotatingKeys()
    {
        //Shift + WASD-keys/arrows to rotate
        if (Input.GetKey(accesRotationKey))
        {
            moveSpeed = 0.0f;
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            curXRot += -y * rotateSpeed;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXrot);
            transform.eulerAngles = new Vector3(curXRot, transform.eulerAngles.y + (x * rotateSpeed), 0.0f);
        }
        else
        {
            moveSpeed = 30.0f;
        }
    }

    private void MovingMouse()
    {
        //Right-MB + drag to move
        if (Input.GetMouseButton(0))
        {
            Vector3 forward = cam.transform.forward;
            forward.y = 0.0f;
            forward.Normalize();
            Vector3 right = cam.transform.right.normalized;

            float moveX = Input.GetAxisRaw("Mouse X");
            float moveZ = Input.GetAxisRaw("Mouse Y");

            Vector3 dir = forward * moveZ + right * moveX;
            dir.Normalize();
            dir *= moveSpeed * Time.deltaTime;
            transform.position -= dir;
        }
    }

    private void MovingKeys()
    {
        //WASD-keys/arrows to move
        Vector3 forward = cam.transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        Vector3 right = cam.transform.right.normalized;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = forward * moveZ + right * moveX;
        dir.Normalize();
        dir *= moveSpeed * Time.deltaTime;
        transform.position += dir;
    }
}
