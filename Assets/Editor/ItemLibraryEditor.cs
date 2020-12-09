using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemLibrary))]
public class ItemLibraryEditor : Editor
{

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open Item Creator"))
        {
            ItemCreator window = (ItemCreator)EditorWindow.GetWindow(typeof(ItemCreator));
            window.Show();
        }
        base.OnInspectorGUI();
    }
}
