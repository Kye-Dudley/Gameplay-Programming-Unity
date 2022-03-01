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
    PlayerScoreManager scoreManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpManager = player.GetComponent<PlayerPowerUpManager>();
        scoreManager = player.GetComponent<PlayerScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch(Type)
            {
                case collectableTypes.Coin:
                    scoreManager.increaseScore(1);
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
