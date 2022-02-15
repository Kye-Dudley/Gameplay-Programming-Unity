using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCharacterMovement : MonoBehaviour
{
    private CharacterController controller;

    private float movementX;
    private float movementY;

    private Vector3 playerVelocity;
    private bool grounded;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnJump()
    {
        if (grounded == true)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -5.0f * gravityValue);
        }
    }

    private void Update()
    {
        grounded = controller.isGrounded;
        Debug.Log(("Grounded: ") + controller.isGrounded);
        
        Vector3 move = new Vector3(movementX, 0, movementY);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
