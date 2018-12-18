using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public bool destroyable;
    public float health;
    public bool damages;
    public float damage;

    private void Update()
    {
        if (!CheckHealth())
        {
            Destroy(gameObject);
        }
    }

    // a method to check the obstacle's health
    // returns true if still alive, false otherwise
    private bool CheckHealth()
    {
        if (health < 0)
        {
            return false;
        }
        return true;
    }

    // a method to damage obstacle health
    public void TakeDamage(float damage)
    {
        health -= Mathf.FloorToInt(damage);
        Debug.Log("Obstacle damaged!");
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player") && damages)
        {
            c.collider.SendMessage("TakeDamage", damage);
        }
    }

}
