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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch(Type)
            {
                case collectableTypes.Coin:
                    Debug.Log("Increase Score");
                    break;
                case collectableTypes.DoubleJump:
                    Debug.Log("Enable Double Jump");
                    break;
                case collectableTypes.SpeedBoost:
                    Debug.Log("Enable Speed Boost");
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
