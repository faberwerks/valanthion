using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour {

    private float countdown;

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Entity>().TakeDamage(damage);
        }
    }

    private void Start()
    {
        countdown = 1f;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown  <= 0)
        {
            Destroy(gameObject);
        }
    }
}
