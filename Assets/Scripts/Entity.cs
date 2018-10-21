using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rb;

    protected Vector2 movement = new Vector2(1, 0);
    protected float health;
    protected uint speed;
    protected uint damage;
    protected uint defense;
    protected uint atkSpeed;
    protected bool isFacingRight;
    protected SpriteRenderer sprRend;

    protected void Move()
    {
        switch (isFacingRight)
        {
            case true:
                transform.Translate(movement * speed * Time.deltaTime);
                break;

            case false:
                transform.Translate(movement * -speed * Time.deltaTime);
                break;
        }
    }

    protected void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    protected void Death()
    {
        if (health <= 0)
        {
            DestroyGameObject();
        }
    }

    // Use this for initialization

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int atk)
    {
        Debug.Log(name + "DAMAGE PROCESSED");
        float damage = atk * (100.0f / (100 + GetDefense()));

        SetHealth(GetHealth() - Mathf.FloorToInt(damage));

        Debug.Log(health);
    }

    public float GetHealth()
    {
        return this.health;
    }

    public void SetHealth(float health)
    {
        if (health >= 0)
        {
            this.health = health;
        }
        else
        {
            this.health = 0;
        }
    }

    public uint GetDefense()
    {
        return defense;
    }

    public void SetDefense(uint defense)
    {
        this.defense = defense;
    }

    public bool GetIsFacingRight()
    {
        return this.isFacingRight;
    }

    public void SetIsFacingRight(bool isFacingRight)
    {
        this.isFacingRight = isFacingRight;
    }

}
