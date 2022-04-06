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

    private void Start()
    {
        if (enemyScale == enemyScales.large)
        {

        }
        else if (enemyScale == enemyScales.medium)
        {
            
        }
        else if (enemyScale == enemyScales.small)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyTakeDamage(3);
        }
    }
    void EnemyTakeDamage(int damage)
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

    void EnemySplit()
    {
        if(enemyScale == enemyScales.large)
        {
            GameObject splitslime = this.gameObject;
            splitslime = Instantiate(splitslime);
            splitslime = Instantiate(splitslime);

            EnemyDeath();
        }
        else if (enemyScale == enemyScales.medium)
        {

            EnemyDeath();
        }
        else if (enemyScale == enemyScales.small)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        Debug.Log("Enemy " + gameObject.name + " was killed.");
        Destroy(gameObject);
    }
}
