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
    public enum ItemType { Consumable, Equipment, Material }
    public ItemType itemtype;


    //If consumable
    public enum RestoreType { Health, Mana }
    public RestoreType restoretype;
    public int RestorePoints;

    //If Equipment
    public enum EquipmentSlot { Helm, Chestplate, Legs, Boots, Gloves, Offhand, Cape, Amulet, Ring, Quiver }
    public EquipmentSlot equipmentslot;
    public bool isWeapon;
    public int Damage;
    public int Defense;
}
