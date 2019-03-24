using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Obstacle))]
[CanEditMultipleObjects]
public class ObstacleEditor : Editor {

    SerializedProperty hitSound;
    SerializedProperty destroyable;
    SerializedProperty health;
    SerializedProperty damages;
    SerializedProperty damage;

    private void OnEnable()
    {
        hitSound = serializedObject.FindProperty("hitSound");
        destroyable = serializedObject.FindProperty("destroyable");
        health = serializedObject.FindProperty("health");
        damages = serializedObject.FindProperty("damages");
        damage = serializedObject.FindProperty("damage");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(hitSound);
        EditorGUILayout.PropertyField(destroyable);

        if (destroyable.boolValue)
        {
            EditorGUILayout.PropertyField(health);
        }

        EditorGUILayout.PropertyField(damages);

        if (damages.boolValue)
        {
            EditorGUILayout.PropertyField(damage);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
