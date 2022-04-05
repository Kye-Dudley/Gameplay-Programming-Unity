using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
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
            EnemyDeath();
        }
        else
        {
            currentHealth = currentHealth - damage;
        }
    }

    void EnemyDeath()
    {
        Debug.Log("Enemy " + gameObject.name + " was killed.");
        Destroy(gameObject);
    }
}
