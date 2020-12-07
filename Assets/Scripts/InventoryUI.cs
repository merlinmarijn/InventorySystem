using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject SlotPrefab;
    private List<GameObject> Slots;
    public GameObject SlotHolder;

    private void Start()
    {
        Slots = new List<GameObject>();
    }

    public void UpdateUI(List<Item> itemlist)
    {
        if (Slots != null)
        {
            foreach (GameObject item in Slots)
            {
                Destroy(item);
            }
            Slots.Clear();
        }
        foreach (Item item in itemlist)
        {
            GameObject slot = Instantiate(SlotPrefab);
            Slots.Add(slot);
            slot.transform.SetParent(SlotHolder.transform);
            slot.GetComponentInChildren<TextMeshProUGUI>().text =item.itemName+": "+ item.itemCount.ToString();
            slot.GetComponent<InventoryButton>().itemID = item.itemID;
            slot.GetComponent<InventoryButton>().inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }
    }
}
