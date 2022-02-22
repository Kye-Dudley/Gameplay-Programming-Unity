using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Destroy : MonoBehaviour
{
    public PlayerGameMode gameMode;

    // Start is called before the first frame update
    void Start()
    {
        gameMode = GameObject.Find("Player").GetComponent<PlayerGameMode>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
