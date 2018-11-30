/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Skill))]
[CanEditMultipleObjects]
public class SkillEditor : Editor {
    SerializedProperty skillId;
    SerializedProperty skillName;
    SerializedProperty cooldownTime;
    SerializedProperty executionTime;
    SerializedProperty staminaCost;
    SerializedProperty dealsDamage;
    SerializedProperty singleTarget;
    SerializedProperty multipleTargets;
    SerializedProperty bleeding;
    SerializedProperty damage;
    SerializedProperty bleedingDamage;
    SerializedProperty reducesDefense;
    SerializedProperty dashes;
    SerializedProperty slowsDownTarget;
    SerializedProperty stuns;
    SerializedProperty knocksBack;
    SerializedProperty cripples;
    SerializedProperty isCounter;
    SerializedProperty isStance;
    SerializedProperty buffs;
    SerializedProperty attackStrength;
    SerializedProperty attackSpeed;
    SerializedProperty defense;
    SerializedProperty additionalHealth;
    SerializedProperty additionalStamina;
    SerializedProperty resetsCooldowns;

    private bool dealsDamageToggle = false;
    private bool damageSettings = false;

    private void OnEnable()
    {
        skillId = serializedObject.FindProperty("skillId");
        skillName = serializedObject.FindProperty("skillName");
        cooldownTime = serializedObject.FindProperty("cooldownTime");
        executionTime = serializedObject.FindProperty("executionTime");
        staminaCost = serializedObject.FindProperty("staminaCost");
        dealsDamage = serializedObject.FindProperty("dealsDamage");
        singleTarget = serializedObject.FindProperty("singleTarget");
        multipleTargets = serializedObject.FindProperty("multipleTargets");
        bleeding = serializedObject.FindProperty("bleeding");
        damage = serializedObject.FindProperty("damage");
        bleedingDamage = serializedObject.FindProperty("bleedingDamage");
        reducesDefense = serializedObject.FindProperty("reducesDefense");
        dashes = serializedObject.FindProperty("dashes");
        slowsDownTarget = serializedObject.FindProperty("slowsDownTarget");
        stuns = serializedObject.FindProperty("stuns");
        knocksBack = serializedObject.FindProperty("knocksBack");
        cripples = serializedObject.FindProperty("cripples");
        isCounter = serializedObject.FindProperty("isCounter");
        isStance = serializedObject.FindProperty("isStance");
        buffs = serializedObject.FindProperty("buffs");
        attackStrength = serializedObject.FindProperty("attackStrength");
        attackSpeed = serializedObject.FindProperty("attackSpeed");
        defense = serializedObject.FindProperty("defense");
        additionalHealth = serializedObject.FindProperty("additionalHealth");
        additionalStamina = serializedObject.FindProperty("additionalStamina");
        resetsCooldowns = serializedObject.FindProperty("resetsCooldowns");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(skillId);
        EditorGUILayout.PropertyField(skillName);
        EditorGUILayout.PropertyField(cooldownTime);
        EditorGUILayout.PropertyField(executionTime);
        EditorGUILayout.PropertyField(staminaCost);

        dealsDamageToggle = EditorGUILayout.Toggle("Deals Damage", dealsDamage.boolValue);

        // dealsDamage.boolValue = dealsDamageToggle;

        if (dealsDamageToggle)
        {
            damageSettings = EditorGUILayout.Foldout(damageSettings, "Damage Settings");

            if (damageSettings)
            {
                singleTarget.boolValue = EditorGUILayout.Toggle("Single Target", !multipleTargets.boolValue);
                singleTarget.boolValue = EditorGUILayout.Toggle("Multiple Targets", !singleTarget.boolValue);

                bleeding.boolValue = EditorGUILayout.Toggle("Bleeding", bleeding.boolValue);

                EditorGUILayout.PropertyField(damage);
                if (bleeding.boolValue)
                {
                    EditorGUILayout.PropertyField(bleedingDamage);
                }
            }
        }
    }
}
*/
