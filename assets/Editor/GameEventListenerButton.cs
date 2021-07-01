using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEventListener))]
public class GameEventListenerButton : Editor
{
    public override void OnInspectorGUI()
    {
        GameEventListener gameEventListener = (GameEventListener)target;
        if (gameEventListener.Event != null)
        {
            if (GUILayout.Button("Raise " + gameEventListener.Event.name, GUILayout.Height(50)))
            {
                gameEventListener.Event.Raise();
            }
        }
        DrawDefaultInspector();


    }

}
