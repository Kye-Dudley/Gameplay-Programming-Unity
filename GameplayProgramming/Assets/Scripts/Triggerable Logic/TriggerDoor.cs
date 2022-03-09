using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    private bool activateDelay = false;
    public bool canClose = false;
    public float delay = 0;
    private float delayTimer = 0;
    public int TriggerID;
    private bool isOpen = false;
    public float openSpeed = 5;
    public Vector3 targetOffset;
    private Vector3 initialLocation;
    private void Start()
    {
        //Subscribe our door to the events list
        TriggerEvents.LeverScript.onLeverTrigger += EventDoorActivated;
        TriggerEvents.LeverScript.onLeverTriggerExit += EventDoorDectivated;
        initialLocation = this.transform.position;
        targetOffset = this.transform.position + targetOffset;
    }

    private void EventDoorActivated(int id)
    {
        if(id == this.TriggerID)
        {
            activateDelay = true;
        }

    }
    private void EventDoorDectivated(int id)
    {
        if (id == this.TriggerID)
        {
            activateDelay = true;
        }
    }

    private void openDoor()
    {
        Debug.Log("Door: " + "Door with the ID of: " + TriggerID + " was Opened.");
 //       this.gameObject.transform.position = this.gameObject.transform.position + Vector3.up * 3;
        isOpen = true;
//        Destroy(this.gameObject);
    }
    private void closeDoor()
    {
        if(canClose == true)
        {
            Debug.Log("Door: " + "Door with the ID of: " + TriggerID + " was Closed.");
//            this.gameObject.transform.position = this.gameObject.transform.position + Vector3.down * 3;
            isOpen = false;
        }
    }

    private void Update()
    {
        if (activateDelay == true)
        {
            delayTimer = delayTimer + Time.deltaTime;
            if(delayTimer >= delay)
            {
                activateDelay = false;
                delayTimer = 0;
                if(isOpen) { closeDoor(); }
                else { openDoor(); }
            }
        }
        if(isOpen == true)
        {
            this.gameObject.transform.position = Vector3.Lerp(transform.position, targetOffset, Time.deltaTime * openSpeed);
        }
        else
        {
            this.gameObject.transform.position = Vector3.Lerp(transform.position, initialLocation, Time.deltaTime * openSpeed);
        }
    }

    private void OnDestroy()
    {
        //Unsubscrive our door from the event list when it is destroyed
        TriggerEvents.LeverScript.onLeverTrigger -= EventDoorActivated;
        TriggerEvents.LeverScript.onLeverTriggerExit -= EventDoorDectivated;
    }
}
