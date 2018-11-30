using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Player>().Health = 0;

        }
        else if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<Enemy>().Health = 0;
        }
    }
}