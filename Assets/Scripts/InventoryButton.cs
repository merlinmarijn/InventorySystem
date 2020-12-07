using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public int itemID;
    [HideInInspector]
    public Inventory inv;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("left Click");
            inv.UseItem(itemID);
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("Middle Click");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Debug.Log("Right Click");
            inv.DropItem(itemID);
        }
    }
}
