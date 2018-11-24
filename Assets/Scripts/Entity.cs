using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected SpriteRenderer sprRend;

    protected float health;
    protected float atkSpeed;

    protected int speed;
    protected int defense;

    protected float atk;

    protected bool isFacingRight;
   
    // a method to move entity
    protected void Move()
    {
        switch (isFacingRight)
        {
            case true:
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                break;

            case false:
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
        }
    }

    // a method to handle entity death
    protected virtual void CheckDeath()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // a method to damage entity health
    public virtual void TakeDamage(float atk)
    {
        float damage = atk * (100.0f / (100 + Defense));

        Health -= Mathf.FloorToInt(damage);
    }

    /////// PROPERTIES ///////
    public float Health
    {
        get
        {
            return this.health;
        }
        set
        {
            if (health > 0.0f)
            {
                health = value;
            }
            else
            {
                this.health = 0.0f;
            }
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }
        set
        {
            this.defense = value;
        }
    }

    public bool IsFacingRight
    {
        get
        {
            return isFacingRight;
        }
        set
        {
            this.isFacingRight = value;
        }
    }

    public float Atk
    {
        get
        {
            return atk;
        }
    }
}
