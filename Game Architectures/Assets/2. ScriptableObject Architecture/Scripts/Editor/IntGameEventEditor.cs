using Architectures.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IntGameEvent))]
public class IntGameEventEditor : Editor
{
    private int value;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IntGameEvent intEvent = (IntGameEvent)target;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Int Value");
        value = EditorGUILayout.IntField(value);

        if (GUILayout.Button("Raise Event"))
        {
            intEvent.Raise(value);
        }
        EditorGUILayout.EndHorizontal();
    }
}
