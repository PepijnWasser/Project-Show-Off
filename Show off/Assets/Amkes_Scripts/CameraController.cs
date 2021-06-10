using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeedKeys;
    public float moveSpeedMouse;
    public float minXRot;
    public float maxXrot;
    public float minZoom;
    public float maxZoom;
    public float zoomSpeed;
    public float rotateSpeed;
    public GameObject camObject;
    public float minXBound;
    public float maxXBound;
    public float minZBound;
    public float maxZBound;

    private float curXRot;
    private float curZoom;
    private Camera cam;
    //private KeyCode zoomInKey = KeyCode.Q;
    //private KeyCode zoomOutKey = KeyCode.E;
    //private KeyCode accesRotationKey = KeyCode.LeftShift;

    private void Start()
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXRot = camObject.transform.rotation.x;
    }

    private void Update()
    {
        //Zooming
        ZoomingMouse();         //Scrollwheel
        //ZoomingKeys();

        //Rotating
        RotatingMouse();        //Right-MB + Drag
        RotatingKeys();         //Q+E keys

        //Moving
        MovingMouse();          //Left-MB + Drag
        MovingKeys();           //WASD- or Arrow-keys
    }

    private void ZoomingMouse()
    {
        curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);
        cam.transform.localPosition = Vector3.up * curZoom;
    }

    /*
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
    */

    private void RotatingMouse()
    {
        //Right-MB + Drag
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxisRaw("Mouse X");
            transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y + (x * rotateSpeed), 0.0f);
        }
    }

    private void RotatingKeys()
    {
        //Q+E keys
        if (Input.GetKey(KeyCode.Q))
        {
            //Left
            transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y + (-1 * rotateSpeed), 0.0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            //Right
            transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y + (1 * rotateSpeed), 0.0f);
        }
    }

    private void MovingMouse()
    {
        //Left-MB + Drag
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
            dir *= moveSpeedMouse * Time.deltaTime;
            transform.position -= dir;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXBound, maxXBound), transform.position.y, Mathf.Clamp(transform.position.z, minZBound, maxZoom));
        }
    }

    private void MovingKeys()
    {
        //WASD- or Arrow-keys
        Vector3 forward = cam.transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        Vector3 right = cam.transform.right.normalized;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = forward * moveZ + right * moveX;
        dir.Normalize();
        dir *= moveSpeedKeys * Time.deltaTime;
        transform.position += dir;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXBound, maxXBound), transform.position.y, Mathf.Clamp(transform.position.z, minZBound, maxZoom));
    }
}
