using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUI : MonoBehaviour
{
    ItemLibrary IL;
    public GameObject SlotHolder;
    public GameObject prefab;
    private void Start()
    {
        IL = GameObject.FindGameObjectWithTag("bgSystem").GetComponent<ItemLibrary>();
        foreach (Item item in IL.getItemCollection())
        {
            GameObject button = Instantiate(prefab, SlotHolder.transform);
            button.GetComponent<PickupButton>().itemID = item.itemID;
            button.GetComponentInChildren<Text>().text = item.itemName;
        }
    }
}
