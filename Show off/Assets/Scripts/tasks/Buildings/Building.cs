using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool active;
    public bool showMenu;
    public GameObject menu;

    void Update()
    {
        CheckColor();
        CheckClicked();
        ShowMenu();
    }

    void CheckColor()
    {
        if (active)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }
    }

    void CheckClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    showMenu = true;
                }
                else
                {
                    showMenu = false;
                    Debug.Log(hit.collider.name + " " + this.name);
                }
            }
        }
    }
    void ShowMenu()
    {
        if(menu != null)
        {
            if (showMenu && active)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }      
    }
}
