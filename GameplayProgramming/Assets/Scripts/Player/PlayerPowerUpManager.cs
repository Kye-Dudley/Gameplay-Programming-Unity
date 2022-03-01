using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpManager : MonoBehaviour
{
    CharacterMovement movementScript;
    private float speedBoostIncrease;
    bool speedBoostActive;
    bool doubleJumpActive;

    private void Start()
    {
        movementScript = GetComponent<CharacterMovement>();
    }

    public void activateSpeedBoost()
    {
        Debug.Log("Speed Boost Activated!");
    }

    public void activateDoubleJump()
    {
        Debug.Log("Jump Boost Activated!");
    }
}
