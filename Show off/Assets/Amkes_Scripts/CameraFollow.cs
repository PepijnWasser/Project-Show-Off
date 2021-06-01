//UNUSED SCRIPT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothness;
    public Transform targetObject;

    private Vector3 initialOffset;
    private Vector3 cameraPosition;

    void Start()
    {
        initialOffset = transform.position - targetObject.position;
    }

    void Update()
    {
        cameraPosition = targetObject.position + initialOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.deltaTime);
    }
}
