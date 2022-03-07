using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CutsceneTrigger : MonoBehaviour
{
    public int id;
    private Camera playerCam;
    private void Start()
    {
        //Subscribe our camera to the events list
        TriggerEvents.LeverScript.onLeverTrigger += onCutsceneActive;
        GetComponent<Camera>().enabled = false;
        playerCam = Camera.main;
    }

    private void onCutsceneActive(int id)
    {
        if (id == this.id)
        {
            GetComponent<Camera>().enabled = true;
            playerCam.enabled = false;
            FindObjectOfType<PlayerInput>().enabled = false;
            Debug.Log("Cutscene: " + "Cutscene with the ID of: " + id + " was Activated.");
        }
    }

    private void OnDestroy()
    {
        //Unsubscrive our camera from the event list when it is destroyed
        TriggerEvents.LeverScript.onLeverTrigger -= onCutsceneActive;    
    }
}
