using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int atk = 20;

    public float knockback = 5.0f;

    private string parentTag;
    private string targetTag;

    void Start()
    {
        parentTag = GetComponentInParent<Entity>().tag;
        if (parentTag == "Player")
        {
            targetTag = "Enemy";
        }
        else
        {
            targetTag = "Player";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.name == targetTag)
        {
            Debug.Log("ENEMY!");
            collision.SendMessageUpwards("Damage", atk);

            if (gameObject.GetComponentInParent<Entity>().IsFacingRight)
            {
                knockback *= 1;
            }
            else
            {
                knockback *= -1;
            }

            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, 2.5f);
        }
    }
}
