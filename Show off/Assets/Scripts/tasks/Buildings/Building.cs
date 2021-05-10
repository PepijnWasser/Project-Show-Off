using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool active;

    void Update()
    {
        if (active)
        {
            GetComponent<Renderer>().material.SetColor("_color", new Color(200, 200, 200));
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_color", new Color(100, 100, 100));
        }
    }
}
