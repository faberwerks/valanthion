using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gameManager.CurrState = GameManager.GameState.DEFEAT;
        }
        Destroy(coll.gameObject);
    }
}