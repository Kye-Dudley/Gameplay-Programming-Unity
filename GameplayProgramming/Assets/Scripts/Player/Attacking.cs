using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    private CharacterMovement movement;

    public bool isAttacking;
    private bool damageOnce = true;
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
            if(isAttacking)
            {
                if(damageOnce)
                {
                    other.GetComponentInChildren<AI_Slime_Split>().takeDamage(1);
                    damageOnce = false;
                }
            }
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
                damageOnce = true;
            }
            else
            {
//                movement.enabled = false;
                transform.parent.GetComponentInChildren<Animator>().SetTrigger("Attacking");
                currentAttackTime = currentAttackTime + Time.deltaTime;
            }
        }
        else
        {
            currentAttackTime = 0;
        }
    }
}
