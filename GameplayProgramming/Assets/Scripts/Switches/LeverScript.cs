using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TriggerEvents.LeverScript.onLeverActivate();
    }
}
