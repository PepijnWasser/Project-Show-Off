using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRotation : MonoBehaviour
{
    [SerializeField] private GameObject inputField;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        if (inputField.activeSelf == true)
        {
            transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y + (1 * rotateSpeed), 0.0f);
            rotateSpeed = Mathf.Clamp(rotateSpeed, rotateSpeed, rotateSpeed);
        }
    }
}
