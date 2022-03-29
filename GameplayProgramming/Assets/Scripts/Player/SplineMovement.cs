using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplineMovement : MonoBehaviour
{
    private Vector2 movementVector;
    PlayerInput controller;
    FollowSpline followSplineScript;
    Vector3 currentOffsetPos;

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
            controller.enabled = true;
            followSplineScript.canMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}