using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseStateController))]

public class StateMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var nodesList = serializedObject.FindProperty("Condtions");
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
