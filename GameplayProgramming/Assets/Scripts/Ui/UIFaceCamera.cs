using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{

    void Update()
    {
        transform.LookAt(Camera.current.transform);
    }
}
