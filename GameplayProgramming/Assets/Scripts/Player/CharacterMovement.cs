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
    public float acceleration = 10;
    public float rotationSpeed = 10;
    public float jumpHeight = 10;
    private bool jumpInput;

    //Physics
    Vector3 intendedDirection;
    Vector3 velocity;
    Vector3 velocityXZ;
    public float gravity = 9.81f;
    bool MovingOnGround = false;
    bool resetGrav;

    private float cyoteTime = 0.15f;
    private float jumpBuffer = 0.1f;
    private float jumpBufferTimer;
    private float playerAirTime;

    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnMove(InputValue movementValue)
    {
        //Setting the movement vector to our input on X and Y.
        //movementVector is the equivalent of input.getAxis for the new input system.
        movementVector = movementValue.Get<Vector2>();
    }

    private void OnJump()
    {
        jumpInput = true;
    }

    private void Update()
    {
        calculateInput();
        calculateCamera();
        calculateGround();
        calculateMovement();
        calculateGravity();
        updateAnimations();
        //        calculateJump();
        if (jumpInput == true)
        {
            //jumpBufferTimer = jumpBuffer;
            jumpBufferTimer = jumpBuffer;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }

        if(jumpBufferTimer > 0)
        {
            calculateJump();
        }

        //Resets the player's velocity when they hit a ceiling. 
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            if (velocity.y > 0)
            {
                velocity.y = -1;
            }
        }

        //Update the player's movement after movePlayer() has been updated.
        controller.Move(velocity * Time.deltaTime);

        jumpInput = false;
    }

    void updateAnimations()
    {
        animator.SetFloat("MovSpeed", controller.velocity.magnitude);
        animator.SetBool("OnGround", MovingOnGround);
    }

    void calculateInput()
    {

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

    void calculateGround()
    {
//        RaycastHit hit;
//        if(Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 0.2f))
        if ((controller.collisionFlags & CollisionFlags.Below) != 0)

        {
            playerAirTime = 0;
            MovingOnGround = true;
        }
        else
        {
            MovingOnGround = false;
            playerAirTime += Time.deltaTime;
        }
    }
    
    void calculateMovement()
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

        //Movement is only on the X and Y. Seperates the Y axis for gravity.
        velocityXZ = velocity;
        velocityXZ.y = 0;
        velocityXZ = Vector3.Lerp(velocityXZ, transform.forward * movementVector.magnitude * movementSpeed, acceleration * Time.deltaTime);
        velocity = new Vector3(velocityXZ.x, velocity.y, velocityXZ.z);
    }

    void calculateGravity()
    {
        if (MovingOnGround == true)
        {
            //reset velocity.y. Keep the value low-ish so the player can move down slopes.
            velocity.y = -15f;
            resetGrav = true;
        }
        else
        {
            if (resetGrav == true)
            {
                velocity.y = -1f;
                resetGrav = false;
            }
            //begin moving the player down when they are not on the ground.
            velocity.y -= gravity * Time.deltaTime;
        }
        //Clamp the gravity so the player can't fall too fast.
        velocity.y = Mathf.Clamp(velocity.y, -50, Mathf.Infinity);
    }

    void calculateJump()
    {
        if (playerAirTime < cyoteTime)
        {
            resetGrav = false;

            playerAirTime = cyoteTime;
            jumpBufferTimer = 0f;
            velocity.y = jumpHeight;
        }
    }
}
