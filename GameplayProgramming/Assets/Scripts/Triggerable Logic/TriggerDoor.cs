using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public int id;
    private void Start()
    {
        //Subscribe our door to the events list
        TriggerEvents.LeverScript.onLeverTrigger += onDoorActivated;
        TriggerEvents.LeverScript.onLeverTriggerExit += onDoorDectivated;

    }

    private void onDoorActivated(int id)
    {
        if(id == this.id)
        {
            Debug.Log("Door: " + "Door with the ID of: " + id + " was Opened.");
        }

    }
    private void onDoorDectivated(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Door: " + "Door with the ID of: " + id + " was Closed.");
        }
    }
}
