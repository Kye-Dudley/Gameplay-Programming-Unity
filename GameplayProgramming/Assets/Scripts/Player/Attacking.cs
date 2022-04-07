using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(other.gameObject.name != "Vision")
            {
                other.GetComponentInChildren<AIHealth>().EnemyTakeDamage(3);
            }
        }
    }
}
