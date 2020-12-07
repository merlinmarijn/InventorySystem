using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickupButton : MonoBehaviour, IPointerClickHandler
{
    public int itemID;
    private Inventory inv;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                inv.Additem(itemID, true, 10);
                return;
            }
            inv.Additem(itemID);
        }
    }
}
