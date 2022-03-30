using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTransform : MonoBehaviour
{
    private Transform initialTransform;

    public bool lockPosition = false;
    public bool lockRotation = false;
    public bool lockScale = false;

    private void Start()
    {
        initialTransform = transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(lockPosition)
        {
            transform.position = initialTransform.position;
        }
        if (lockRotation)
        {
            transform.rotation = initialTransform.rotation;
        }
        if (lockScale)
        {
            transform.localScale = initialTransform.localScale;
        }
    }
}
