using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnIsland : MonoBehaviour
{
    [SerializeField] private float keyboardSensitivity;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;

    //public Transform targetTransform;

    private Vector3 targetPos = new Vector3(0,0,0);

    private void Start()
    {
        //targetPos = targetTransform.position;
    }

    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomIn(mouseSensitivity);
        }

        if (Input.GetKey(KeyCode.E))
        {
            ZoomIn(keyboardSensitivity);
        }

        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOut(mouseSensitivity);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            ZoomOut(keyboardSensitivity);
        }
    }

    void ZoomIn(float sensitivity)
    {
        Vector3 dVec = targetPos - this.transform.position;
        float distance = dVec.magnitude;

        Vector3 newVec = this.transform.position + Vector3.forward * sensitivity * Time.deltaTime;

        if (distance > minDistance && newVec.magnitude > minDistance)
        {
            this.transform.Translate(Vector3.forward * sensitivity * Time.deltaTime);
        }
        else
        {
            this.transform.position = -dVec.normalized * minDistance;
        }
    }

    void ZoomOut(float sensitivity)
    {
        Vector3 dVec = targetPos - this.transform.position;
        float distance = dVec.magnitude;

        Vector3 newVec = this.transform.position + Vector3.forward * -sensitivity * Time.deltaTime;

        if (distance < maxDistance && newVec.magnitude < maxDistance)
        {
            this.transform.Translate(Vector3.forward * -sensitivity * Time.deltaTime);
        }
        else
        {
            this.transform.position = -dVec.normalized * maxDistance;
        }
    }
}
