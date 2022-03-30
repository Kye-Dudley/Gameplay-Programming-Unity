using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SplineMovement : MonoBehaviour
{
    private bool isActive;
    private Vector2 movementVector;
    PlayerInput controller;
    FollowSpline followSplineScript;
    public Transform playerAttach;
    private GameObject player;

    void Start()
    {
        controller = GetComponent<PlayerInput>();
        followSplineScript = GetComponentInParent<FollowSpline>();
        
        controller.enabled = false;
    }
    private void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
        transform.localPosition = new Vector3(movementVector.x * 2, movementVector.y * 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isActive = true;
            player = other.gameObject;

            player.GetComponent<PlayerInput>().enabled = false;
            player.GetComponent<CharacterMovement>().enabled = false;
            player.transform.parent = playerAttach;
            player.transform.localPosition = Vector3.zero;

            controller.enabled = true;
            followSplineScript.canMove = true;
            GetComponent<CameraOverride>().OverrideCamera();
            Destroy(GetComponent<Collider>());
        }
    }
    private void Update()
    {
        if(isActive)
        {
            if (followSplineScript.gameObject.transform.position != followSplineScript.path.path.GetPointAtDistance(followSplineScript.distanceProgress))
            {
                isActive = false;
                Debug.Log("player has reached end!");

                controller.enabled = false;
                followSplineScript.canMove = false;

                GetComponent<CameraOverride>().ReturnToMainCamera();
                player.GetComponent<PlayerInput>().enabled = true;
                player.GetComponent<CharacterMovement>().enabled = true;
                player.transform.parent = null;



            }
        }
    }
}
