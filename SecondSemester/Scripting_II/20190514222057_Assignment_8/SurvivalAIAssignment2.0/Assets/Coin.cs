using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameEngine gameEngine;

    void OnTriggerEnter(Collider other)
    {
        gameEngine.AddCoin();
        Destroy(gameObject);
    }
}
