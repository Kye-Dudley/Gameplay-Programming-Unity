using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvents : MonoBehaviour
{
    public static TriggerEvents LeverScript;

    private void Awake()
    {
        LeverScript = this;
    }

    public event Action<int> onLeverTrigger;
    public void onLeverActivate(int id)
    {
        if(onLeverTrigger != null)
        {
            onLeverTrigger(id);
            Debug.Log("Event Manager: " + "A Lever with the ID of: " + id + " triggered onLeverActivate.");
        }
    }

    public event Action<int> onLeverTriggerExit;
    public void onLeverDeactivate(int id)
    {
        if (onLeverTriggerExit != null)
        {
            onLeverTriggerExit(id);
            Debug.Log("Event Manager: " + "A Lever with the ID of: " + id + " triggered onLeverDeactivate.");
        }
    }

}
