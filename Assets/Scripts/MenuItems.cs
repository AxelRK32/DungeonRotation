using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuItems : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image pointer;
    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponentsInChildren<Image>(true)[1];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointer.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointer.enabled = false;
    }
}
