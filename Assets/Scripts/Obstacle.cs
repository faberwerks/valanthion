using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.collider.tag == "Player")
        {
            c.transform.GetComponent<Player>().TakeDamage(20.0f);
            Destroy(gameObject);
        }
    }

}
