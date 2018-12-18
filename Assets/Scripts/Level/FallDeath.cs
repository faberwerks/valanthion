using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Enemy"))
        {
            coll.gameObject.GetComponent<Entity>().Health = 0;

        }
    }
}