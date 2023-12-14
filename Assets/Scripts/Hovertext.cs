using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hovertext : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverText.SetActive(false);
    }
}
