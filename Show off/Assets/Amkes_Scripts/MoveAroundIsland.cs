using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundIsland : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        UseKeyboardControls();
        //UseMouseControls();
    }

    private void UseKeyboardControls()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        speed = Mathf.Clamp(speed, 25, 25);
    }

    private void UseMouseControls()
    {
        if (Input.GetMouseButton(1))
        {

        }
    }
}
