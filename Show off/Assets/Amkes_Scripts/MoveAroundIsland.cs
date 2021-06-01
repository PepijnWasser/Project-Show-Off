using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundIsland : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        UseKeyboardControls();
    }

    private void UseKeyboardControls()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        speed = Mathf.Clamp(speed, 25, 25);
    }
}
