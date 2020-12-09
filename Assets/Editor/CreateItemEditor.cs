using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemLibrary))]
[CanEditMultipleObjects]
public class CreateItemEditor : Editor
{


    private ItemLibrary IL;
    private string Name;
    private string Description;
    private bool FocusOnCreation;
    private enum ItemType { Consumable, Equipment, Material }
    private enum RestoreType { Health, Mana }
    private ItemType IT;
    private RestoreType RT;
    private int RestorePoints;
    public enum EquipmentSlot { Helm, Chestplate, Legs, Boots, Gloves, Weapon,Offhand, Cape, Amulet, Ring, Quiver }
    public EquipmentSlot equipmentslot;
    public int damage;
    public int defense;

    public override void OnInspectorGUI()
    {
        //Enumerator that tells me what type of item im going to make
        IT = (ItemType)EditorGUILayout.EnumPopup("Type of item", IT);
        IL = (ItemLibrary)target;
        EditorGUILayout.Space();
        //Set Basic variables that EVERY ITEM NEEDS
        EditorGUILayout.LabelField("Basic variables:");
        Name = EditorGUILayout.TextField("Name", Name);
        Description = EditorGUILayout.TextField("Description", Description);
        EditorGUILayout.Space();

        //Set variables for every CONSUMEABLE ITEM
        switch (IT)
        {
            case ItemType.Consumable:
            EditorGUILayout.LabelField("Consumable variables:");
            RestorePoints = EditorGUILayout.IntField("Restores points", RestorePoints);
            RT = (RestoreType)EditorGUILayout.EnumPopup("Restore Type", RT);
            break;

            case ItemType.Equipment:
            EditorGUILayout.LabelField("Equipment variables:");
                //PUT STUFF HERE
                if (equipmentslot == EquipmentSlot.Weapon || equipmentslot == EquipmentSlot.Quiver)
                {
                    damage = EditorGUILayout.IntField("Damage Points", damage);
                }
                else
                {
                    defense = EditorGUILayout.IntField("Defense Points", defense);
                }
                equipmentslot = (EquipmentSlot)EditorGUILayout.EnumPopup("Equipment Slot", equipmentslot);
                break;

            case ItemType.Material:
            EditorGUILayout.LabelField("Material variables:");
                //PUT STUFF HERE
                break;
        }

        EditorGUILayout.Space();
        //Set input fields for creating/deleteing/focusing
        FocusOnCreation = EditorGUILayout.Toggle("Focus on Creation", FocusOnCreation);
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate Item"))
        {
            CreateItem(new Item());
        }
        if (GUILayout.Button("Remove Last"))
        {
            RemoveLast();
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        base.OnInspectorGUI();
    }



    private void CreateItem(Item type)
    {
        //Debug.Log(IL);
        AssetDatabase.CreateAsset(type, "Assets/Items/" + IL.GetCollectionCount()+"-"+Name + type.name.Replace(" ", "") + ".asset");
        AssetDatabase.SaveAssets();
        type.itemID = IL.GetCollectionCount();
        type.itemName = Name;
        type.itemDescription = Description;
        type.itemCount = 1;
        switch (IT)
        {
            case ItemType.Consumable:
                type.itemtype = Item.ItemType.Consumable;
                switch (RT)
                {
                    case RestoreType.Health:
                        type.restoretype = Item.RestoreType.Health;
                        break;
                    case RestoreType.Mana:
                        type.restoretype = Item.RestoreType.Mana;
                        break;
                }
                type.RestorePoints = EditorGUILayout.IntField("Restores", RestorePoints);
                break;
            case ItemType.Equipment:
                type.itemtype = Item.ItemType.Equipment;
                type.isWeapon = true;
                if (equipmentslot==EquipmentSlot.Weapon || equipmentslot==EquipmentSlot.Quiver) { type.Damage = damage; } else { type.Defense = defense; }
                break;
            case ItemType.Material:
                type.itemtype = Item.ItemType.Material;
                break;
        }
        IL.AddToCollection(type);
        EditorUtility.FocusProjectWindow();
        if (FocusOnCreation) { Selection.activeObject = type; }
    }

    private void RemoveLast()
    {
        AssetDatabase.DeleteAsset("Assets/Items/" + IL.getItemByIndex(IL.GetLastIndex()).name + ".asset");
        IL.RemoveLast();
    }
}
