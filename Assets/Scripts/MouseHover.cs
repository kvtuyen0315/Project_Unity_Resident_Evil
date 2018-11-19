using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool active = true;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (active == true)
        {
            transform.Rotate(0, -5, 0);
        }
        active = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (active == false)
        {
            transform.Rotate(0, +5, 0);
        }
        active = true;
    }
}
