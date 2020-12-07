using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemLibrary))]
[CanEditMultipleObjects]
public class CreateItemEditor : Editor
{


    public ItemLibrary IL;
    public string Name;
    public string Description;
    private bool FocusOnCreation;


    public override void OnInspectorGUI()
    {
        IL = (ItemLibrary)target;
        Name = EditorGUILayout.TextField("Name", Name);
        Description = EditorGUILayout.TextField("Description", Description);
        FocusOnCreation = EditorGUILayout.Toggle("Focus on Creation", FocusOnCreation);
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Generate Item"))
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
        Debug.Log(IL);
        AssetDatabase.CreateAsset(type, "Assets/Items/" + IL.GetCollectionCount()+"-"+Name + type.name.Replace(" ", "") + ".asset");
        AssetDatabase.SaveAssets();
        type.itemID = IL.GetCollectionCount();
        type.itemName = Name;
        type.itemDescription = Description;
        type.itemCount = 1;
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
