using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHotelTask : Task
{
    public GameObject clickTarget;

    public override void CheckTask()
    {
        TestHit();
    }

    public override void Reset()
    {
        completed = false;
    }

    void TestHit()
    {
        if (clickTarget != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == clickTarget)
                    {
                        completed = true;
                    }
                }
            }
        }
        else
        {
            clickTarget = GameObject.FindGameObjectWithTag("Hotel");
        }
    }
}