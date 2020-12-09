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
            if(Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.LeftControl))
            {
                inv.Additem(itemID, true, 100);
                return;
            } else if (Input.GetKey(KeyCode.LeftShift))
            {
                inv.Additem(itemID, true, 10);
                return;
            } else if (Input.GetKey(KeyCode.LeftControl)){
                inv.Additem(itemID, true, 5);
                return;
            }
            inv.Additem(itemID);
        }
    }
}
