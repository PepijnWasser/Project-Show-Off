using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverSprite;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        HoverSprite.SetActive(true);
        //Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        HoverSprite.SetActive(false);
        //Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
