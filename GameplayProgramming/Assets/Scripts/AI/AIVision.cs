using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour
{
    private AIRoam roamScript;
    private AIFollow followScript;

    private void Start()
    {
        roamScript = GetComponentInParent<AIRoam>();
        followScript = GetComponentInParent<AIFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Enemy can see player!");
            followScript.moveTo = other.gameObject;
            roamScript.enabled = false;
            followScript.enabled = true;
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enemy can no longer see player!");
            followScript.enabled = false;
            roamScript.enabled = true;
        }
    }
}
