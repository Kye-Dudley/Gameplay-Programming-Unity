using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    private void Start()
    {
        //Subscribe our door to the events list
        TriggerEvents.LeverScript.onLeverTrigger += onDoorActivated;
    }

    private void onDoorActivated()
    {
        Debug.Log("Open Door");
    }
}
