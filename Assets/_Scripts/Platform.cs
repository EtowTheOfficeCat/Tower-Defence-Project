﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Platform : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
   

    public static PlatformEvent Clicked = new PlatformEvent();

    [SerializeField] Color hoverColor;
    Color normalColor;
    Renderer rend;
    //private bool canBeClicked = true;
    public bool IsOccupied { get; set; } = false;

    private void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        normalColor = rend.material.GetColor("_BaseColor");
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // if (canBeClicked == false) { return; }
        if (IsOccupied == true) { return; }
        
        rend.material.SetColor("_BaseColor", hoverColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        rend.material.SetColor("_BaseColor", normalColor);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //if (canBeClicked == false) { return; }
        if(IsOccupied == true) { return;}
        IsOccupied = false;
        //canBeClicked = false;
        //Vector3 platPos = transform.position;
        //Clicked?.Invoke(new Vector3(platPos.x, platPos.y , platPos.z));
        Clicked?.Invoke(this);

    }

}


