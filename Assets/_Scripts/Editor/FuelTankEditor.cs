using UnityEngine;
using UnityEditor;

using UnityEditor.SceneManagement;
using System;

[CustomEditor(typeof(FuelTank))]
public class FuelTankEditor : Editor {


    SerializedProperty energyProp;

    FuelTank cible;



    private void OnEnable()
    {
        cible = (FuelTank)target;
        energyProp = serializedObject.FindProperty("energy");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();
        cible.Energy = EditorGUILayout.IntSlider(energyProp.intValue, 0, cible.MaxEnergy);
        try
        {
            ProgressBar((float)cible.Energy / cible.MaxEnergy, "Energy");

        }
        catch (DivideByZeroException)
        {
            Debug.Log("Ressource Manager Editor ==>> MaxEnergie es à 0");
        }
        catch(Exception e)
        {
            Debug.Log("Ressource Manager Editor ==>>  message d'erreur " + e.Message);
        }

        cible.MaxEnergy = EditorGUILayout.IntField("Max Energy", cible.MaxEnergy);

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
        
    }


    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }

}
