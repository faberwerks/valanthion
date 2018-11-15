using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected SpriteRenderer sprRend;

    protected float health;
    protected float atkSpeed;

    protected uint speed;
    protected int atk;
    protected uint defense;
    protected bool isFacingRight;
   
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

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // a method to damage entity health
    public virtual void TakeDamage(float atk)
    {
        float damage = atk * (100.0f / (100 + Defense));

        Health = Health - Mathf.FloorToInt(damage);
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

    public uint Defense
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

    public int Atk
    {
        get
        {
            return atk;
        }
    }
}
