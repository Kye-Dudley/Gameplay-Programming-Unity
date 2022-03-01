using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum collectableTypes
    {
        Coin,
        DoubleJump,
        SpeedBoost
    };
    [SerializeField]
    collectableTypes Type;
    GameObject player;
    PlayerPowerUpManager powerUpManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpManager = player.GetComponent<PlayerPowerUpManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch(Type)
            {
                case collectableTypes.Coin:
                    //Coin collected
                    break;
                case collectableTypes.DoubleJump:
                    powerUpManager.activateDoubleJump();
                    break;
                case collectableTypes.SpeedBoost:
                    powerUpManager.activateSpeedBoost();
                    break;
            }
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 3, 0);
    }
}
