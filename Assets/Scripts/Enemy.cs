using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    enum State : byte { Roam, Chase, Attack };

    public GameManager gameManager;

    public GameObject player;

    public Collider2D attackTriggerLeft;
    public Collider2D attackTriggerRight;
    private Collider2D attackTrigger;

    protected Vector3 originalPos;

    private RaycastHit2D hit;

    protected byte state;

    protected float attackTimer;
    protected float attackCd;
    protected float yMin;

    private int playerLayer;
    protected int expValue;

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
        state = (byte)State.Roam;
        attackTimer = 0;
        attackCd = 2f;
        expValue = 100;

        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Death();
        switch (GetState())
        {
            case (byte)State.Roam:
                Invoke("Roam", 0.5f);
                break;
            case (byte)State.Chase:
                Chase();
                break;
            case (byte)State.Attack:
                Attack();
                break;
        }

    }

    protected void Roam()
    {
        if (GetIsFacingRight())
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, 5.0f, playerLayer);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 5.0f, playerLayer);
        }

        if (hit)
        {
            SetState((byte)State.Chase);
            return;
        }

        if (GetIsFacingRight())
        {

            if (transform.position.x - originalPos.x <= 3)

            {
                SetIsFacingRight(true);
                Move();

            }

            else
            {
                SetIsFacingRight(false);
                Move();

            }

        }

        else

        {

            if (transform.position.x - originalPos.x >= -3)

            {
                SetIsFacingRight(false);
                Move();

            }

            else

            {
                SetIsFacingRight(true);
                Move();

            }

        }

    }

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

        hit = Physics2D.Raycast(transform.position, (GetIsFacingRight() ? Vector2.right : Vector2.left), 5.0f, playerLayer);
        if (hit)
        {
            SetIsFacingRight(GetIsFacingRight());
            Move();
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, (GetIsFacingRight() ? Vector2.left : Vector2.right), 5.0f, playerLayer);
            if (hit)
            {
                SetIsFacingRight(!GetIsFacingRight());
                Move();
            }
            else
            {
                SetState((byte)State.Roam);
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
            SetState((byte)State.Attack);
            return;
        }

    }

    protected void Attack()
    {

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            attackTimer = attackCd;

            if (GetIsFacingRight())
            {
                attackTrigger = attackTriggerRight;
            }
            else
            {
                attackTrigger = attackTriggerLeft;
            }

            attackTrigger.enabled = true;
        }

        hit = Physics2D.Raycast(transform.position, (GetIsFacingRight() ? Vector2.right : Vector2.left), 5.0f, playerLayer);
        if (!hit)
        {
            hit = Physics2D.Raycast(transform.position, (GetIsFacingRight() ? Vector2.left : Vector2.right), 5.0f, playerLayer);
            if (!hit)
            {
                SetState((byte)State.Roam);
                return;
            }
        }

    }

    protected void Death()
    {
        if (health <= 0)
        {
            gameManager.Exp(expValue);
            DestroyGameObject();
        }
    }

    public byte GetState()
    {
        return this.state;
    }

    public void SetState(byte state)
    {
        this.state = state;
    }

    public int GetExp()
    {
        return this.expValue;
    }

    public void SetExp(int expValue)
    {
        this.expValue = expValue;
    }

}
