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
                break;
            case ItemType.Equipment:
                break;
            case ItemType.Material:
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
