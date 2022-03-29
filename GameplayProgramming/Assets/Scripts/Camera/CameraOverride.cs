using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOverride : MonoBehaviour
{
    [Header("Cinemachine Override Options")]
    public bool overrideFreeLook = false;
    public CinemachineFreeLook freeLook;
    public GameObject freeLookAt;

    [Header("Camera Switch Options")]
    public bool switchCamera = false;
    public Camera newCamera;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(switchCamera)
            {
                Debug.Log("Camera Switched!");
                newCamera.enabled = true;
                other.GetComponentInChildren<Camera>().enabled = false;
            }
            if(overrideFreeLook)
            {
                Debug.Log("FreeLook Switched!");
                freeLook.LookAt = freeLookAt.transform;
                freeLook.Follow = transform;
            }
        }
    }
}
