﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected SpriteRenderer sprRend;

    protected Animator anim;

    protected float maxStamina;
    protected float initialMaxStamina;

    protected float health;
    protected float maxHealth;
    protected float initialMaxHealth;
    protected float atkSpeed;
    protected float initialAtkSpeed;

    protected int speed;
    protected int defense;
    protected int initialSpeed;
    protected int initialDefense;

    protected float atk;
    protected float initialAtk;

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

    // a method to slow down entity
    protected void SlowDown(int slowDownSpeed)
    {
        initialSpeed = speed;
        speed -= slowDownSpeed;
        StartCoroutine(CSlowDown(5.0f));
    }

    // a method to knock back entity
    protected void KnockBack(float force)
    {
        rb.AddForce(new Vector2(1.0f, 0) * force, ForceMode2D.Impulse);
    }

    // a method to stun entity
    protected void Stun()
    {
        initialSpeed = speed;
        initialAtk = atk;

        speed = 0;
        atk = 0;
        StartCoroutine(CStun(5.0f));
    }

    // a method to bleed entity
    protected void Bleed()
    {
        StartCoroutine(CBleed(5.0f));
    }

    // a method to reduce defense temporarily
    protected void ReduceDefense(int reduction)
    {
        initialDefense = defense;
        defense -= reduction;
        StartCoroutine(CReduceDefense(5.0f));
    }

    // a method to cripple entity
    protected void Cripple(int atkReduction)
    {
        initialSpeed = speed;
        initialAtk = atk;

        speed = 0;
        atk -= atkReduction;

        StartCoroutine("CCripple", 5.0f);
    }

    public void ApplyBuffs(BuffInfo buffInfo)
    {
        if (buffInfo.additionalHealth)
        {
            initialMaxHealth = health;
            maxHealth += 20;
        }
        if (buffInfo.additionalStamina)
        {
            initialMaxStamina = maxStamina;
            maxStamina += 20;
        }
        if (buffInfo.attackSpeed)
        {
            initialAtkSpeed = atkSpeed;
            atkSpeed -= 1;
        }
        if (buffInfo.attackStrength)
        {
            initialAtk = atk;
            atk += 20;
        }
        if (buffInfo.defense)
        {
            initialDefense = defense;
            defense += 20;
        }

        StartCoroutine(CApplyBuffs(5.0f));
    }

    /////// COROUTINES ///////
    // slow down timer
    protected IEnumerator CSlowDown(float time)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return 0;
        }

        speed = initialSpeed;
        yield break;
    }

    // stun timer
    protected IEnumerator CStun(float time)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return 0;
        }

        speed = initialSpeed;
        atk = initialAtk;
        yield break;
    }

    // bleeding damage
    protected IEnumerator CBleed(float time)
    {
        float timer = time;
        float secondCounter = 0;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            secondCounter += Time.deltaTime;

            if (secondCounter >= 1.0f)
            {
                TakeDamage(1.0f);
                secondCounter = 0;
            }

            yield return 0;
        }

        yield break;
    }

    // reduce defense timer
    protected IEnumerator CReduceDefense(float time)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return 0;
        }

        defense = initialDefense;
        yield break;
    }

    // cripple timer
    protected IEnumerator CCripple(float time)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return 0;
        }

        speed = initialSpeed;
        atk = initialAtk;
        yield break;
    }

    // apply buff timer
    public IEnumerator CApplyBuffs(float time)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return 0;
        }

        atk = initialAtk;
        atkSpeed = initialAtkSpeed;
        defense = initialDefense;
        maxHealth = initialMaxHealth;
        maxStamina = initialMaxStamina;

        yield break;
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