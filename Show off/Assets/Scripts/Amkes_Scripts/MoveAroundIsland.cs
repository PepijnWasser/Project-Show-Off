//UNUSED + OLD SCRIPT
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
    }

    private void UseKeyboardControls()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //Make sure speed doesn't go up when moving diagonally
        speed = Mathf.Clamp(speed, 25, 25);
    }
}
