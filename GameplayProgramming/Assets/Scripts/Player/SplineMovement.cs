using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplineMovement : MonoBehaviour
{
    private Vector2 movementVector;
    PlayerInput controller;
    Vector3 currentOffsetPos;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerInput>();
        controller.enabled = false;
    }
    private void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
        Debug.Log("Spline Controller Input Recieved!");
//        Vector3.Lerp((transform.position), new Vector3(movementVector.x, movementVector.y, transform.position.z), Time.deltaTime * 2);
        transform.position = new Vector3(transform.position.x, movementVector.y + transform.position.y, movementVector.x + transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerInput>().enabled = false;
            controller.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
