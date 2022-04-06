using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public GameObject moveTo;
    public bool canSeePlayer = false;

    private float currentRoamTimer = 0;
    private float RoamTimer = 5;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(canSeePlayer)
        {
            navMeshAgent.SetDestination(moveTo.transform.position);
        }
        else 
        {
            currentRoamTimer = currentRoamTimer + Time.deltaTime;
            if(currentRoamTimer >= RoamTimer)
            {
                GetComponentInChildren<AIVision>().playerLost();
                currentRoamTimer = 0;
            }
            else
            {
                navMeshAgent.SetDestination(moveTo.transform.position);
            }
        }
    }
}
