﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Patrol();
    void Guard();
    void Chase();
    void Attack();
    void Retreat();
}

public class Enemy : Entity
{
    //public AudioSource audioSource;

    //public AudioClip enemyDeath;
    
    public enum EnemyState : byte { PATROL, GUARD, CHASE, ATTACK, RETREAT }

    protected GameObject player;

    protected StageSetting stageSetting;

    protected Vector3 originalPos;

    protected Vector2 currDir;

    protected Weapon weapon;



    public EnemyState initialState;
    protected EnemyState currState;

    protected float atkTimer;
    protected float distance;
    protected float range;
    public float detectionRange;

    protected int playerLayer;

    protected ushort expValue;

    protected void Move()
    {
        anim.SetFloat("Speed", 1.0f);

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

    protected void Flip(bool faceRight)
    {
        IsFacingRight = faceRight;

        Vector3 scale = transform.localScale;

        if (faceRight)
        {
            scale.x = 1;
        }
        else
        {
            scale.x = -1;
        }
        transform.localScale = scale;
    }

    protected override void CheckDeath()
    {
        if (Health <= 0)
        {
            //audioSource.PlayOneShot(enemyDeath);
            stageSetting.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    // a method to get a reference to the stage setting
    public void SetStageSetting(StageSetting stageSetting)
    {
        this.stageSetting = stageSetting;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Flip();
    }

    /////// COROUTINES ///////
    /*
    protected IEnumerator CTimeColorChange()
    {
        sprRend.color = new Color(255f, 0.0f, 0.0f, 255f);
        colorTimer = colorTime;

        while (colorTimer > 0)
        {
            colorTimer -= Time.deltaTime;
            yield return 0;
        }

        sprRend.color = new Color(255f, 255f, 255f, 255f);
        yield break;
    }
    */

    /////// PROPERTIES ///////
    public EnemyState InitialState
    {
        get
        {
            return initialState;
        }
        set
        {
            this.initialState = value;
        }
    }

    public EnemyState CurrState
    {
        get
        {
            return currState;
        }
        set
        {
            this.currState = value;
        }
    }

    public ushort ExpValue
    {
        get
        {
            return expValue;
        }
        set
        {
            this.expValue = value;
        }
    }

}
