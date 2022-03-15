using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpManager : MonoBehaviour
{
    CharacterMovement movementScript;
    
    //Speed Boost
    bool speedBoostActive;
    private float speedBoostTimer;
    public float speedBoostTimeLimit = 10;
    private float defaultGroundSpeed;
    private float defaultAirSpeed;
    public TrailRenderer speedTrail;

    //Double Jumping
    bool doubleJumpActive;
    private float doubleJumpTimer;
    public float doubleJumpTimeLimit = 10;
    public TrailRenderer jumpTrail;


    private void Start()
    {
        movementScript = GetComponent<CharacterMovement>();
        defaultGroundSpeed = movementScript.groundSpeed;
        defaultAirSpeed = movementScript.airControl;
    }

    public void activateSpeedBoost()
    {
        if (speedBoostActive == false)
        {
            speedBoostActive = true;
            speedBoostTimer = 0;
            movementScript.groundSpeed = movementScript.groundSpeed + 5;
            movementScript.airControl = movementScript.airControl + 5;
            speedTrail.enabled = true;
            Debug.Log("Speed Boost Activated!");
        }
        else
        {
            speedBoostActive = true;
            speedBoostTimer = 0;
            Debug.Log("Speed Boost Re-Activated!");
        }
    }

    public void activateDoubleJump()
    {
        doubleJumpActive = true;
        doubleJumpTimer = 0;
        movementScript.maxJumpCount = 3;
        jumpTrail.enabled = true;
        Debug.Log("Jump Boost Activated!");
    }

    private void Update()
    {
        if(speedBoostActive)
        {
            speedBoostTimer = speedBoostTimer + Time.deltaTime;
            if(speedBoostTimer >= speedBoostTimeLimit)
            {
                Debug.Log("Speed Boost Deactivated!");
                movementScript.groundSpeed = defaultGroundSpeed;
                movementScript.airControl = defaultAirSpeed;
                speedBoostActive = false;
                speedTrail.enabled = false;
            }
        }

        if(doubleJumpActive)
        {
            doubleJumpTimer = doubleJumpTimer + Time.deltaTime;
            if(doubleJumpTimer >= doubleJumpTimeLimit)
            {
                Debug.Log("Jump boost Deactivated!");
                movementScript.maxJumpCount = 1;
                doubleJumpActive = false;
                jumpTrail.enabled = false;
            }
        }
    }
}
