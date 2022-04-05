using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRoamAI : MonoBehaviour
{
    enum AIStatus
    {
        Roaming,
        FollowPlayer,
        LockingOnPlayer,
        FightingPlayer
    }
    AIStatus currentStatus;

    [Header("Enemy Movement")]

    public float movementSpeed;

    [Header("Health & Combat")]
    public int maxHealth;
    private int currentHealth;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void EnemyRoam()
    {
        //AI move to random position. 
        //once reached, repeat. 
    }

    void EnemyFollowPlayer()
    {
        //Move to player's position + lock on range. 
        //Once in range, Lock on. 
    }

    void EnemyLockingOnPlayer()
    {
        //Follow the player just outside of the range. 
        //Test to see if any AI enemies are currently locking on.
        ///If there is, repeat.
        ///If not, lock on to the player and enter fighting.
    }

    void EnemyFightingPlayer()
    {
        //follow the player inside of the range area.
        //if the player can be hit and the enemy can attack, enter attack.
    }

    void EnemyAttackPlayer()
    {
        //Attack the player. 
        //Return to fighting.
    }

    void EnemyTakeDamage()
    {
        //Move enemy back
        //Take Damage
        if(currentHealth <= 0)
        {
            EnemyDeath();
        }
        else
        {
            EnemyLockingOnPlayer();
        }
        //Enter Locking on to player.
    }

    void EnemyDeath()
    {
        Debug.Log("Enemy " + gameObject.name + " was killed.");
        Destroy(gameObject);
    }
}
