using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    private CharacterMovement movement;

    public bool isAttacking;
    private float attackTimer = 0.5f;
    private float currentAttackTime = 0;
    private void Start()
    {
        movement = GetComponentInParent<CharacterMovement>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponentInChildren<AIHealth>().EnemyTakeDamage(1);
        }
    }

    private void Update()
    {
        if (movement.interactInput)
        {
            if(movement.MovingOnGround)
            {
                if(!isAttacking)
                {
                    isAttacking = true;
                }
            }
        }
        if(isAttacking)
        {

            if(currentAttackTime >= attackTimer)
            {
//                movement.enabled = true;
                isAttacking = false;
            }
            else
            {
//                movement.enabled = false;
                transform.parent.GetComponentInChildren<Animator>().SetTrigger("Attacking");
                currentAttackTime = currentAttackTime + Time.deltaTime;
                Debug.Log(currentAttackTime);
            }
        }
        else
        {
            currentAttackTime = 0;
        }
    }
}
