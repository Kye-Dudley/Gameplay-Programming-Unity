using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_EnemySlimeStates : MonoBehaviour
{
    public enum slimeStates
    {
        Idle,
        Roam,
        Follow,
        Combat,
        Flee
    }
    [Header("Slime Enemy Variables")]
    public slimeStates currentSlimeState = slimeStates.Roam;
    public Vector3 slimeFollowVector;
    private NavMeshAgent navAgent;

    [Header("Slime Roaming Variables")]
    public float roamingRange = 10;
    public float roamingDelay = 5;

    [Header("Slime Following Variables")]
    public bool canSeePlayer = false;
    public float exitFollowTime = 3;
    private float currentExitFollowTime = 0;

    private void Awake()
    {
        if(currentSlimeState == slimeStates.Roam)
        {
            navAgent = GetComponent<NavMeshAgent>();

            UpdateRoamLocation();

            navAgent.SetDestination(slimeFollowVector);

            StartCoroutine(RoamPath());
        }
    }
    IEnumerator RoamPath()
    {
        if(currentSlimeState == slimeStates.Roam)
        {
            navAgent.SetDestination(slimeFollowVector);
            UpdateRoamLocation();
            yield return new WaitForSeconds(roamingDelay);
            StartCoroutine(RoamPath());
        }
    }
    void UpdateRoamLocation()
    {
        slimeFollowVector = new Vector3(Random.Range(-roamingRange, roamingRange), 0, Random.Range(-roamingRange, roamingRange)) + transform.position;
    }

    private void FixedUpdate()
    {
        if(currentSlimeState == slimeStates.Follow)
        {
            if(canSeePlayer)
            {
                navAgent.SetDestination(slimeFollowVector);
            }
            else
            {
                exitFollowTime = exitFollowTime + Time.deltaTime;
                if (exitFollowTime >= currentExitFollowTime)
                {
                    currentSlimeState = slimeStates.Roam;
                    exitFollowTime = 0;
                    StartCoroutine(RoamPath());

                    Debug.Log("Slime lost player. Return to roam");
                }
                else
                {
                    navAgent.SetDestination(slimeFollowVector);
                }
            }
        }
    }

    public void startFollowingPlayer(Vector3 moveTo)
    {
        Debug.Log("Enemy vision cone found player");
        currentSlimeState = slimeStates.Follow;
        canSeePlayer = true;
        exitFollowTime = 0;
    }
}