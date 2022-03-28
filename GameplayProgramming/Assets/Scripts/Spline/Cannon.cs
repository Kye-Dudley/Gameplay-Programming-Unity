using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Cannon : MonoBehaviour
{
    FollowSpline followSplineScript;
    float movementSpeed = 1;
    PathCreator path;

    private void Start()
    {
        path = GetComponentInChildren<PathCreator>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            followSplineScript = other.gameObject.AddComponent<FollowSpline>();
            followSplineScript.speed = movementSpeed;
            followSplineScript.canMove = true;
            followSplineScript.path = path;
            followSplineScript.updateRotation = FollowSpline.rotation.Y;
            other.GetComponent<CharacterController>().enabled = false;
            other.GetComponent<CharacterMovement>().enabled = false;
            other.GetComponentInChildren<Animator>().SetBool("Rolling", true);
        }
    }
}
