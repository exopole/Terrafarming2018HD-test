using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerMoving : MonoBehaviour {

    public float rotationAmountX = 1.0f;
    public float rotationAmountY = 1.0f;
    public CameraController cameraController;

    Vector3 mousePositionRef;

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            mousePositionRef = Input.mousePosition;
            Cursor.visible = false;
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = Input.mousePosition - mousePositionRef;
            cameraController.H += rotationAmountX * mousePosition.x;
            cameraController.V += rotationAmountY * mousePosition.y;

            mousePositionRef = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
        }
        
    }
}
