using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

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
        transform.rotation = Quaternion.Euler(cameraTilt, cameraHeading, 0);

        transform.position = player.position - transform.forward * camDistance;
    }
}
