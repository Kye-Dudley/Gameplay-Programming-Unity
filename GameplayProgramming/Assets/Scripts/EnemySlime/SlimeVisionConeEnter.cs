using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeVisionConeEnter : MonoBehaviour
{
    AI_EnemySlimeStates slimeStateScript;
    private void Start()
    {
        slimeStateScript = GetComponentInParent<AI_EnemySlimeStates>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            slimeStateScript.startFollowingPlayer(other.transform.position);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            slimeStateScript.slimeFollowVector = other.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            slimeStateScript.canSeePlayer = false;
        }
    }
}
