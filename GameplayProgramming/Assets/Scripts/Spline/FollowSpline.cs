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
    public enum rotation
    {
        none,
        YZ,
        XYZ
    }
    public rotation updateRotation;

    void Start()
    {
        transform.position = path.path.GetPointAtDistance(0);
    }

    void FixedUpdate()
    {
        if(canMove == true)
        {
            splineMove();
            splineRotate();
        }
    }

    void splineMove()
    {
        distanceProgress += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distanceProgress);
    }

    void splineRotate()
    {
        if (updateRotation == rotation.none)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        }
        else if (updateRotation == rotation.XYZ)
        {
            transform.localRotation = path.path.GetRotationAtDistance(distanceProgress);
            transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 90);
        }
        else if (updateRotation == rotation.YZ)
        {
            transform.localRotation = path.path.GetRotationAtDistance(distanceProgress);
            transform.localRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 90);
        }

    }

    void splineReset()
    {
        canMove = false;
        transform.position = path.path.GetPointAtDistance(0);
    }
    
}
