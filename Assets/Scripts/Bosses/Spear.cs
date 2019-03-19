using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

    [SerializeField]
    private float speed;

    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left*Time.deltaTime*speed);
        if(transform.position.x <= -10)
        {
            Death();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Entity>().TakeDamage(damage);
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
