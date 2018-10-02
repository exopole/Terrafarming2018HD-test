using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(JetPackSO))]
public class JetPackPlayerCustomEditor : Editor
{

    SerializedProperty terrainsProperty;

    JetPackSO res;

    TerrainEnum terrains;


    private void OnEnable()
    {
        res = (JetPackSO)target;
        terrainsProperty = serializedObject.FindProperty("terrains");
    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        //terrains = (TerrainEnum)EditorGUILayout.EnumMaskField("Terrains", enumValue: terrains);
        terrains = (TerrainEnum)EditorGUILayout.EnumFlagsField(terrains);
        res.Terrain = terrains;
        serializedObject.ApplyModifiedProperties();
        DrawDefaultInspector();
    }
}