using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 1;
    public bool movingOnGround;
    public float jumpHeight = 400;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnJump()
    {
        if(movingOnGround == true)
        {
            movingOnGround = false;
            rb.AddForce(Vector3.up * jumpHeight);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);


        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down, out hit,Mathf.Infinity,LayerMask.GetMask("Ground")))
        {
            Debug.Log("Moving On Ground");
            movingOnGround = true;
        }
        else
        {
            movingOnGround = false;
        }
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.3F, Color.red, 0, false);
    }
}
