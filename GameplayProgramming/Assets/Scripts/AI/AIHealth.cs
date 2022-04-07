using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public enum enemyScales
    {
        large,
        medium,
        small
    }
    public enemyScales enemyScale;
    public int maxHealth;
    private int currentHealth;
    private bool canBeHit;

    private float invunTimer = 2;
    private float currentInvunTime = 0;

    private void Start()
    {
        if (enemyScale == enemyScales.large)
        {
            canBeHit = true;
        }
        else if (enemyScale == enemyScales.medium)
        {
            canBeHit = false;
        }
        else if (enemyScale == enemyScales.small)
        {
            canBeHit = false;
        }
    }

    private void Update()
    {
        if(!canBeHit)
        {
            if (currentInvunTime >= invunTimer)
            {
                canBeHit = true;
            }
            else
            {
                currentInvunTime = currentInvunTime + Time.deltaTime;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerWeapon")
        {
            if(other.GetComponentInChildren<Attacking>().isAttacking == true)
            {
                EnemyTakeDamage(1);
            }
        }
    }
    public void EnemyTakeDamage(int damage)
    {
        if(canBeHit)
        {
            if (currentHealth <= 0)
            {
                EnemySplit();
            }
            else
            {
                currentHealth = currentHealth - damage;
            }
        }
    }

    void EnemySplit()
    {
        currentInvunTime = 0;
        canBeHit = false;
        GameObject splitslime = this.gameObject;

        if (enemyScale == enemyScales.large)
        {
            splitslime.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            enemyScale = enemyScales.medium;
            splitslime = Instantiate(splitslime);
            splitslime = Instantiate(splitslime);
        }
        else if (enemyScale == enemyScales.medium)
        {
            splitslime.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            enemyScale = enemyScales.small;
            splitslime = Instantiate(splitslime);
            splitslime = Instantiate(splitslime);
            splitslime = Instantiate(splitslime);
        }
        EnemyDeath();
    }

    void EnemyDeath()
    {
        Debug.Log(enemyScale + " enemy '" + gameObject.name + "' was killed.");
        Destroy(gameObject);
    }
}
