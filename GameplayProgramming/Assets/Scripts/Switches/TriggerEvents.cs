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

    public event Action onLeverTrigger;
    public void onLeverActivate()
    {
        if(onLeverTrigger != null)
        {
            onLeverTrigger();
            Debug.Log("Lever Activate");
        }
    }

}
