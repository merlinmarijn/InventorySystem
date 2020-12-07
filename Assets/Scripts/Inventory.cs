using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> inventory;
    ItemLibrary IL;
    InventoryUI IUI;


    private void Start()
    {
        inventory = new List<Item>();
        IL = GameObject.FindGameObjectWithTag("bgSystem").GetComponent<ItemLibrary>();
        IUI = GameObject.FindGameObjectWithTag("invUI").GetComponent<InventoryUI>();

        //Check entire collection of items if it works
        //foreach (Item item in IL.getItemCollection())
        //{
        //    Debug.Log("ID: " + item.itemID + ", Name: " + item.itemName + ", Description: " + item.itemDescription + ", Count: " + item.itemCount);
        //}

        Additem(2, false);
        Additem(1, false, 2);
        Additem(3, false);
        Additem(0, false, 3);
        updateInventoryUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {

                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {

                return;
            }
        }
        //debug log inventory contents
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Additem(0);
            //Debug.ClearDeveloperConsole();
            //if (inventory != null)
            //{
            //    foreach (Item item in inventory)
            //    {
            //        Debug.Log(item.itemCount);
            //    }
            //}
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SortInventory();
        }
    }

    public void Additem(int itemID, bool UpdateUI = true, int amount = 1)
    {
        if (inventory != null)
        {
            foreach (Item item in inventory)
            {
                if (item.itemID == itemID)
                {
                    item.itemCount += amount;
                    if (UpdateUI) { updateInventoryUI(); }
                    return;
                }
            }
        }
        inventory.Add(IL.getItemById(itemID));
        if (UpdateUI) { updateInventoryUI(); }
    }

    public void SwapItemSlot(int index1, int index2)
    {
        Item saveditem = inventory[index1];
        inventory[index1] = inventory[index2];
        inventory[index2] = saveditem;
    }

    public void SortInventory()
    {
        int LastItemID=-10;
        int LastItemIndex= -10;
        if (inventory != null)
        {
            foreach (Item item in inventory)
            {
                if (item.itemID < LastItemID)
                {
                    SwapItemSlot(inventory.IndexOf(item), LastItemIndex);
                    SortInventory();
                    break;
                }
                LastItemID = item.itemID;
                LastItemIndex = inventory.IndexOf(item);
                updateInventoryUI();
            }
        }
    }

    public void UseItem(int ItemID)
    {
        if (inventory != null)
        {
            foreach(Item item in inventory)
            {
                if (item.itemID == ItemID)
                {
                    if (item.itemCount <= 1) { inventory.Remove(item); } else {
                    item.itemCount--;
                }
                    updateInventoryUI();
                    return;
                }
            }
        }
    }

    public void DropItem(int itemID)
    {
        if (inventory != null)
        {
            foreach(Item item in inventory)
            {
                if(item.itemID == itemID)
                {
                    item.itemCount = 1;
                    inventory.Remove(item);
                    updateInventoryUI();
                    return;
                }
            }
        }
    }


    private void updateInventoryUI()
    {
        IUI.UpdateUI(inventory);
    }
}
