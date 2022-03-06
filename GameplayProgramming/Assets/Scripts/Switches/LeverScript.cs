using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TriggerEvents.LeverScript.onLeverActivate(id);
            Debug.Log("Lever: " + "Lever with the ID of: " + id + " was pulled (Active).");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TriggerEvents.LeverScript.onLeverDeactivate(id);
            Debug.Log("Lever: " + "Lever with the ID of: " + id + " was pulled (Deactive).");
        }
    }
}
