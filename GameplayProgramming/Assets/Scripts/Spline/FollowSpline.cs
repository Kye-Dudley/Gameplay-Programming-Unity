using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowSpline : MonoBehaviour
{
    public PathCreator path;
    public bool canMove = true;
    public float speed;
    private float distanceProgress;

    void Start()
    {
        transform.position = path.path.GetPointAtDistance(0);
    }

    void Update()
    {
        if(canMove == true)
        {
            splineMove();
        }
    }

    void splineMove()
    {
        distanceProgress += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distanceProgress);
    }

    void splineReset()
    {
        canMove = false;
        transform.position = path.path.GetPointAtDistance(0);
    }
    
}
