using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeverScript : MonoBehaviour
{
    public int TriggerID;
    private CharacterMovement player;
    private bool overlapping;
    private bool isflipped = false;
    public Transform leverStick;

    private void Start()
    {
        leverStick.localRotation = Quaternion.Euler(0, 0, 30);
        player = FindObjectOfType<CharacterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            overlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            overlapping = false;
        }
    }

    private void Update()
    {
        if (player.interactInput == true && overlapping == true)
        {
            if (isflipped)
            {
                TriggerEvents.LeverScript.onLeverActivate(TriggerID);
                Debug.Log("Lever: " + "Lever with the ID of: " + TriggerID + " was pulled (True).");
                isflipped = false;
            }
            else
            {
                TriggerEvents.LeverScript.onLeverDeactivate(TriggerID);
                Debug.Log("Lever: " + "Lever with the ID of: " + TriggerID + " was pulled (False).");
                isflipped = true;
            }
        }
        if(isflipped)
        {
            leverStick.localRotation = Quaternion.Lerp(leverStick.transform.localRotation, Quaternion.Euler(0, 0, 30), 5f * Time.deltaTime);

        }
        else
        {
            leverStick.localRotation = Quaternion.Lerp(leverStick.transform.localRotation, Quaternion.Euler(0, 0, -30), 5f * Time.deltaTime);

        }
    }
}
