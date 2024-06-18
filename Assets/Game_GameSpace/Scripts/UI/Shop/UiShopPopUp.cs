using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiShopPopUp : MonoBehaviour
{
    public UiShopElement[] shopElements;

    private void OnValidate()
    {
        if(shopElements == null || shopElements.Length == 0)
        {
            shopElements = GetComponentInChildren<UiShopElement[]>();
        }
        
    }

    private void Awake()
    {
        SetData(); 
    }

    private void SetData()
    {
        for (int i = 0; i < shopElements.Length; i++)
        {
            shopElements[i].SetData(i + 1);
        }
    }
}
