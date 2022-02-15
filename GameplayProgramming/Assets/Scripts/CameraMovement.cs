using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Transform camera;

    public float cameraSensitivityX = 180;
    private Vector2 lookVector;
    float cameraHeading = 0;
    float cameraTilt = 15;
    float camDistance = 10;

    private void OnLook(InputValue lookValue)
    {
        lookVector = lookValue.Get<Vector2>();
    }

    private void Update()
    {
        cameraHeading += lookVector.x * Time.deltaTime * cameraSensitivityX;
        camera.transform.rotation = Quaternion.Euler(cameraTilt, cameraHeading, 0);

        camera.transform.position = this.transform.position - camera.transform.forward * camDistance;
    }
}
