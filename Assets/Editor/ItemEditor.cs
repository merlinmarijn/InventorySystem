using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
[CanEditMultipleObjects]
public class ItemEditor : Editor
{
    Item item;
    public override void OnInspectorGUI()
    {
        item = (Item)target;
        item.itemID = EditorGUILayout.IntField("ItemID", item.itemID);
        item.itemName = EditorGUILayout.TextField("Name", item.itemName);
        item.itemDescription = EditorGUILayout.TextField("Description", item.itemDescription);
        item.itemCount = EditorGUILayout.IntField("Count", item.itemCount);
        item.itemtype = (Item.ItemType)EditorGUILayout.EnumPopup("Item Type", item.itemtype);
        EditorGUILayout.Space();

        switch (item.itemtype)
        {
            case Item.ItemType.Consumable:
                item.restoretype = (Item.RestoreType)EditorGUILayout.EnumPopup("Restore Type", item.restoretype);
                item.RestorePoints = EditorGUILayout.IntField("Restores ", item.RestorePoints);
                break;
            case Item.ItemType.Equipment:
                break;
            case Item.ItemType.Material:
                break;
        }
    }

}
