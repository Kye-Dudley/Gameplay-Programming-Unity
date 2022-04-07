using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Slime_Split : MonoBehaviour
{
    enum slimeSizes
    {
        Large,
        Medium,
        Small
    }
    slimeSizes slimeSize;
    public int health;

    public void takeDamage(int damage)
    {
        health = health - damage;
        Debug.Log("Enemy took " + damage + " damage");
        if(health <= 0)
        {
            onSplit();
        }
    }

    void onSplit()
    {
        Debug.Log("Enemy has split");
        GameObject splitslime = gameObject;


        if (slimeSize == slimeSizes.Large)
        {
            createMediumSlime(splitslime);
            createMediumSlime(splitslime);
        }
        else if (slimeSize == slimeSizes.Medium)
        {
            createSmallSlime(splitslime);
            createSmallSlime(splitslime);
            createSmallSlime(splitslime);
        }
        Destroy(gameObject);
    }

    void createMediumSlime(GameObject slime)
    {
        Debug.Log("Instantiated a medium Slime!");
        slime = Instantiate(slime);
        slime.GetComponent<AI_Slime_Split>().slimeSize = slimeSizes.Medium;
        slime.GetComponent<AI_Slime_Split>().health = 2;
        slime.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }
    void createSmallSlime(GameObject slime)
    {
        Debug.Log("Instantiated a Small Slime!");
        slime = Instantiate(slime);
        slime.GetComponent<AI_Slime_Split>().slimeSize = slimeSizes.Small;
        slime.GetComponent<AI_Slime_Split>().health = 1;
        slime.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
