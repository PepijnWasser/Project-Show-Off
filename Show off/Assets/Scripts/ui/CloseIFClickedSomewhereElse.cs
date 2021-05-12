using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseIFClickedSomewhereElse : MonoBehaviour
{
    public GameObject button;
    bool active;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)// || hit.collider.gameObject == button)
                {
                    
                }
                else
                {
                    Debug.Log(hit.collider.name);
                    active = false;
                }
            }
            else
            {
                active = false;
            }
        }

        if (active)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void EnablePanel()
    {
        active = true;
        gameObject.SetActive(true);
    }
}
