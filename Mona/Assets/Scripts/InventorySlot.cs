using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    void Start() 
    {
        icon.enabled = true;
    }
    
    public void AddEntry(){
        icon.enabled = false;
    }
}
