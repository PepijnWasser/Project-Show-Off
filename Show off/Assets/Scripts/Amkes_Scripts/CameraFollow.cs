//UNUSED SCRIPT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothness;
    [SerializeField] private Transform targetObject;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;

    private void Start()
    {
        initialOffset = transform.position - targetObject.position;
    }

    private void Update()
    {
        cameraPosition = targetObject.position + initialOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.deltaTime);
    }
}
