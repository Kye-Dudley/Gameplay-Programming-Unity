using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRoam : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public float movementDelay = 5;
    public float roamingRange = 10;
    private Vector3 moveTo;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        UpdateRoamLocation();
        navMeshAgent.SetDestination(moveTo);

        StartCoroutine(RoamPath());
    }

    IEnumerator RoamPath()
    {
        navMeshAgent.SetDestination(moveTo);
        UpdateRoamLocation();
        yield return new WaitForSeconds(movementDelay);
        StartCoroutine(RoamPath());
    }

    void UpdateRoamLocation()
    {
        moveTo = new Vector3(Random.Range(-roamingRange, roamingRange), 0, Random.Range(-roamingRange, roamingRange)) + transform.position;
    }
}
