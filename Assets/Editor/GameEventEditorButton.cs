using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GameEvent gameEvent = (GameEvent)target;

        if (GUILayout.Button("Raise"))
        {
            gameEvent.Raise();
        }
    }
}
