using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SplineMovement : MonoBehaviour
{
    private Vector2 movementVector;
    PlayerInput controller;
    FollowSpline followSplineScript;
    Vector3 currentOffsetPos;
    public Transform playerAttach;

    // Start is called before the first frame update
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
            other.GetComponent<PlayerInput>().enabled = false;
            other.GetComponent<CharacterController>().enabled = false;
            other.GetComponent<CharacterMovement>().enabled = false;
            controller.enabled = true;
            followSplineScript.canMove = true;
            other.transform.parent = playerAttach;
            other.transform.localPosition = Vector3.zero;
            Destroy(GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
