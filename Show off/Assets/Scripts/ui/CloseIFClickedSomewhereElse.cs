using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseIFClickedSomewhereElse : MonoBehaviour
{
    bool active;

    public Canvas canvas;
    public EventSystem m_EventSystem;
    public GameObject activator;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;


    private void Start()
    {
        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            int falseResuts = 0;
            foreach (RaycastResult result in results)
            {
                if (!result.gameObject.transform.IsChildOf(this.transform) && result.gameObject != activator)
                {
                    falseResuts++;
                }
            }

            if(results.Count == 0 || falseResuts == results.Count)
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

    public void ChangePanel()
    {
        if (active)
        {
            active = false;
            gameObject.SetActive(false);
        }
        else
        {
            active = true;
            gameObject.SetActive(true);

        }

    }
}
