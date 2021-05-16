using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEventListener))]
public class GameEventListenerButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GameEventListener gameEventListener = (GameEventListener)target;
        if (GUILayout.Button("Raise Event"))
        {
            gameEventListener.Event.Raise();
        }
    }

}
