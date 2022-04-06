using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour
{
    private AIRoam roamScript;
    private AIFollow followScript;
    private GameObject Player;

    private void Start()
    {
        roamScript = GetComponentInParent<AIRoam>();
        followScript = GetComponentInParent<AIFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player = other.gameObject;
            playerFound();
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            followScript.canSeePlayer = false;
        }
    }

    public void playerFound()
    {
        Debug.Log("Enemy can see player!");
        followScript.moveTo = Player;
        roamScript.enabled = false;
        followScript.enabled = true;
        followScript.canSeePlayer = true;
    }

    public void playerLost()
    {
        Debug.Log("Enemy can no longer see player!");
        followScript.enabled = false;
        roamScript.enabled = true;
    }
}
