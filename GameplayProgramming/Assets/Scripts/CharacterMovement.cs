using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //Camera
    public Transform cam;
    private Vector3 camF;
    private Vector3 camR;

    //Movement
    private CharacterController controller;
    Vector2 movementVector;
    public float movementSpeed = 5;
    public float acceleration = 2;
    public float rotationSpeed = 10;

    //Physics
    Vector3 intendedDirection;
    Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnMove(InputValue movementValue)
    {
        //Setting the movement vector to our input on X and Y.
        //movementVector is the equivalent of input.getAxis for the new input system.
        movementVector = movementValue.Get<Vector2>();
    }

    private void Update()
    {
        calculateInput();
        calculateCamera();
        movePlayer();
    }

    void calculateInput()
    {
        //Rotate our camera. cameraSensitivity# is the degrees per second.


        //Clamp the vector so it can only reach a maximum of 1.
        movementVector = Vector2.ClampMagnitude(movementVector, 1);

    }

    void calculateCamera()
    {
        //camF is forwards camera direction. camR is right camera direction.
        camF = cam.forward;
        camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
    }

    void movePlayer()
    {
        //Moves the player.
        //transform.position += new Vector3(movementVector.x, 0, movementVector.y) * Time.deltaTime * movementSpeed;

        //Moves the player based on camera direction.
        intendedDirection = camF * movementVector.y + camR * movementVector.x;
        ///magnitude is the amount of input. are we moving at all?
        if(movementVector.magnitude > 0)
        {
            //Lerps rotation speed and input to create a smooth rotation when turning.
            Quaternion rot = Quaternion.LookRotation(intendedDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
        velocity = Vector3.Lerp(velocity, transform.forward * movementVector.magnitude * movementSpeed, acceleration * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

    }
}
