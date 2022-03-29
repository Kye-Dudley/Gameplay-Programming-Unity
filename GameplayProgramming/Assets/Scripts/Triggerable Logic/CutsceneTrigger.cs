using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CutsceneTrigger : MonoBehaviour
{
    public int TriggerID;
    private Camera playerCam;
    public float CutsceneTime = 3;
    private float CutsceneCurrentTime;
    private bool CutsceneActive = false;
    public bool Replayable = false;
    private GameObject player;

    private void Start()
    {
        //Subscribe our camera to the events list
        TriggerEvents.LeverScript.onLeverTrigger += onCutsceneActive;
        TriggerEvents.LeverScript.onLeverTriggerExit += onCutsceneActive;

        GetComponent<Camera>().enabled = false;
        playerCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void onCutsceneActive(int id)
    {
        if (id == this.TriggerID)
        {
            GetComponent<Camera>().enabled = true;
            playerCam.enabled = false;
            player.GetComponent<PlayerInput>().enabled = false;
            Debug.Log("Cutscene: " + "Cutscene with the ID of: " + id + " was Activated.");
            CutsceneActive = true;
        }
    }

    private void onCutsceneEnd(int id)
    {
        if (id == this.TriggerID)
        {
            GetComponent<Camera>().enabled = false;
            playerCam.enabled = true;
            player.GetComponent<PlayerInput>().enabled = true;
            CutsceneActive = false;
            if(Replayable == true)
            {
                CutsceneCurrentTime = 0;
            }
        }
    }

    private void Update()
    {
        if(CutsceneActive)
        {
            CutsceneCurrentTime = CutsceneCurrentTime + Time.deltaTime;
            if(CutsceneCurrentTime >= CutsceneTime)
            {
                onCutsceneEnd(TriggerID);
            }
        }
    }

    private void OnDestroy()
    {
        //Unsubscrive our camera from the event list when it is destroyed
        TriggerEvents.LeverScript.onLeverTrigger -= onCutsceneActive;    
    }
}
