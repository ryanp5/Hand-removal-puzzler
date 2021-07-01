using System;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Transition))]
public class PlayerTransitionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var nodesList = serializedObject.FindProperty("conditions");
        //EditorGUILayout.PropertyField(nodesList);
        TypeCache.TypeCollection types = TypeCache.GetTypesDerivedFrom(typeof(Condtion));

        foreach (var condType in types)
        {
            if (GUILayout.Button("Add " + condType.ToString()))
            {
                var index = nodesList.arraySize;
                nodesList.InsertArrayElementAtIndex(index);
                var prop = nodesList.GetArrayElementAtIndex(index);
                prop.managedReferenceValue = Activator.CreateInstance(condType);
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
