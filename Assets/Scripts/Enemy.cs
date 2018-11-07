using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public enum EnemyState : byte { ROAM, CHASE, ATTACK };

    private GameObject player;

    public Collider2D attackTriggerLeft;
    public Collider2D attackTriggerRight;
    private Collider2D attackTrigger;

    private RaycastHit2D hit;

    protected Vector3 originalPos;

    protected EnemyState currState;

    protected float attackTimer;
    protected float attackCd;
    protected float yMin;

    protected int expValue;
    private int playerLayer;

    private void Awake()
    {
        attackTriggerLeft.enabled = false;
        attackTriggerRight.enabled = false;
        playerLayer = LayerMask.GetMask("Player");
    }

    void Start()
    {
        originalPos = transform.position;
        health = 100;
        speed = 3;
        currState = EnemyState.ROAM;
        attackTimer = 0;
        attackCd = 2f;
        expValue = 100;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Death();
        switch (CurrState)
        {
            case EnemyState.ROAM:
                Invoke("Roam", 0.5f);
                break;
            case EnemyState.CHASE:
                Chase();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
        }
    }

    // a method to handle enemy roaming
    protected void Roam()
    {
        if (IsFacingRight)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, 5.0f, playerLayer);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 5.0f, playerLayer);
        }

        if (hit)
        {
            CurrState = EnemyState.CHASE;
            return;
        }

        if (IsFacingRight)
        {
            if (transform.position.x - originalPos.x <= 3)
            {
                IsFacingRight = true;
                Move();
            }
            else
            {
                IsFacingRight = false;
                Move();
            }
        }
        else
        {
            if (transform.position.x - originalPos.x >= -3)
            {
                IsFacingRight = false;
                Move();
            }
            else
            {
                IsFacingRight = true;
                Move();
            }
        }
    }

    // a method to handle enemy chasing
    protected void Chase()
    {
        /*
        float playerX = player.transform.position.x;

        if (playerX - transform.position.x < 0 && playerX - transform.position.x >= -5)
        {
            isFacingRight = false;
            Move();
        }
        else if (playerX - transform.position.x > 0 && playerX - transform.position.x <= 5)
        {
            isFacingRight = true;
            Move();
        }
        else
        {
            SetState((byte)State.Roam);
            return;
        }
        */

        hit = Physics2D.Raycast(transform.position, (IsFacingRight ? Vector2.right : Vector2.left), 5.0f, playerLayer);
        if (hit)
        {
            IsFacingRight = IsFacingRight;
            Move();
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, (IsFacingRight ? Vector2.left : Vector2.right), 5.0f, playerLayer);
            if (hit)
            {
                IsFacingRight = !IsFacingRight;
                Move();
            }
            else
            {
                CurrState = EnemyState.ROAM;
                return;
            }
        }

        /*
        if(playerX - transform.position.x > 0 && playerX - transform.position.x <= 1)
        {
            SetState((byte)State.Attack);
            return;
        }

        else if (playerX - transform.position.x < 0 && playerX - transform.position.x >= -1)
        {
            SetState((byte)State.Attack);
            return;
        }
        */

        if (hit.distance <= 1.0f)
        {
            CurrState = EnemyState.ATTACK;
            return;
        }
    }

    // a method to handle enemy attacking
    protected void Attack()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            attackTimer = attackCd;

            if (IsFacingRight)
            {
                attackTrigger = attackTriggerRight;
            }
            else
            {
                attackTrigger = attackTriggerLeft;
            }

            attackTrigger.enabled = true;
        }

        hit = Physics2D.Raycast(transform.position, (IsFacingRight ? Vector2.right : Vector2.left), 5.0f, playerLayer);
        if (!hit)
        {
            hit = Physics2D.Raycast(transform.position, (IsFacingRight ? Vector2.left : Vector2.right), 5.0f, playerLayer);
            if (!hit)
            {
                CurrState = EnemyState.ROAM;
                return;
            }
        }
    }

    // a method to handle enemy death
    protected void Death()
    {
        if (health <= 0)
        {
            // gameManager.GiveExp(expValue);
            Destroy(gameObject);
        }
    }

    /////// PROPERTIES ///////
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

    public int ExpValue
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
