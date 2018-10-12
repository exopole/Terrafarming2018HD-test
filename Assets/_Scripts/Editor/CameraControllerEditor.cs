using UnityEngine;
using UnityEditor;

using UnityEditor.SceneManagement;


[CustomEditor(typeof(CameraController))]
public class CameraControllerEditor : Editor {

    CameraController cam;

    public GameObject obj = null;


    SerializedProperty distanceProperty;
    SerializedProperty horizontalProperty;
    SerializedProperty verticalProperty;
    SerializedProperty zoomStepProperty;
    SerializedProperty zoomMinimalProperty;
    SerializedProperty zoomMaxProperty;
    SerializedProperty verticalTextProperty;
    SerializedProperty horizontalTextProperty;
    SerializedProperty smoothProperty;
    SerializedProperty focusProperty;
    SerializedProperty canMoveBottomProperty;
    SerializedProperty radiusDetectProperty;
    SerializedProperty heigthDetectProperty;
    SerializedProperty maskProperty;
    SerializedProperty minHeightProperty;


    private void OnEnable()
    {
        cam = (CameraController)target;
        


        if (!Application.isPlaying)
        {
            //cam.moveCam();
        }
        distanceProperty = serializedObject.FindProperty("distance");
        horizontalProperty = serializedObject.FindProperty("h");
        verticalProperty = serializedObject.FindProperty("v");
        zoomMinimalProperty = serializedObject.FindProperty("minDistance");
        zoomMaxProperty = serializedObject.FindProperty("maxDistance");
        zoomStepProperty = serializedObject.FindProperty("stepZoom");
        verticalTextProperty = serializedObject.FindProperty("verticalText");
        horizontalTextProperty = serializedObject.FindProperty("horizontalText");
        smoothProperty = serializedObject.FindProperty("smooth");
        focusProperty = serializedObject.FindProperty("focus");
        canMoveBottomProperty = serializedObject.FindProperty("canMoveBottom");
        radiusDetectProperty = serializedObject.FindProperty("radiusDetect");
        heigthDetectProperty = serializedObject.FindProperty("heigthDetect");
        maskProperty = serializedObject.FindProperty("mask");
        minHeightProperty = serializedObject.FindProperty("minHeight");

    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        distanceProperty.floatValue = EditorGUILayout.Slider("Distance", cam.Distance, cam.minDistance, cam.maxDistance);
        ////cam.H = EditorGUILayout.Slider("Horizontal angle", cam.H, 0, 360);
        verticalProperty.floatValue = EditorGUILayout.Slider("Vertical angle", cam.V, 0, 90);
        horizontalProperty.floatValue = EditorGUILayout.Slider("Horizontal angle", cam.H, 0, 360);

        EditorGUILayout.PropertyField(focusProperty);
        EditorGUILayout.PropertyField(zoomMinimalProperty);
        EditorGUILayout.PropertyField(zoomMaxProperty);
        EditorGUILayout.PropertyField(zoomStepProperty);
        EditorGUILayout.PropertyField(smoothProperty);
        EditorGUILayout.PropertyField(verticalTextProperty);
        EditorGUILayout.PropertyField(horizontalTextProperty);
        EditorGUILayout.PropertyField(canMoveBottomProperty);
        EditorGUILayout.PropertyField(heigthDetectProperty);
        EditorGUILayout.PropertyField(radiusDetectProperty);
        EditorGUILayout.PropertyField(maskProperty);
        EditorGUILayout.PropertyField(minHeightProperty);

        if (!Application.isPlaying && cam.focus != null )
        {
            cam.MoveSmoothlyCam();
            cam.RotateSmoothlyCam();
        }

        serializedObject.ApplyModifiedProperties();
    }

}
