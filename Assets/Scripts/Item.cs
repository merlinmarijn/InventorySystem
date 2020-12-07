using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Item", menuName = "Create Item")]
public class Item : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemCount = 1;
}
