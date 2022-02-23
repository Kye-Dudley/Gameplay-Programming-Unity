using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Transform Camera;

    public float cameraSensitivityX = 180;
    public float cameraSensitivityY = 180;
    private Vector2 lookVector;
    float cameraHeading = 0;
    float cameraTilt = 15;
    public float camDistance = 10;
    public float playerHeight = 1.5F;

    private void OnLook(InputValue lookValue)
    {
        lookVector = lookValue.Get<Vector2>();
    }

    private void LateUpdate()
    {
        //Calculate Camera X and Y
        cameraHeading += lookVector.x * Time.deltaTime * cameraSensitivityX;
        cameraTilt += -lookVector.y * Time.deltaTime * cameraSensitivityY;

        cameraTilt = Mathf.Clamp(cameraTilt, -80, 80);
        Camera.transform.rotation = Quaternion.Euler(cameraTilt, cameraHeading, 0);

        Camera.transform.position = this.transform.position - Camera.transform.forward * camDistance + Vector3.up * playerHeight;
    }
}
