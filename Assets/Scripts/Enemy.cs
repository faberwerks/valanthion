using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public enum EnemyState : byte { ROAM, GUARD, CHASE, ATTACK };

    protected GameObject player;

    protected EntityAttack entityAttack;

    protected RaycastHit2D hit;

    protected Vector3 originalPos;

    protected Vector2 currDir;

    public EnemyState initialState;
    protected EnemyState currState;

    protected float atkTimer;
    protected float distance;
    // the following variables are to countdown the change colour after getting hit
    protected float colorTime;
    protected float colorTimer;

    protected int expValue;
    protected int playerLayer;

    private void Awake()
    {
        playerLayer = LayerMask.GetMask("Player");
    }

    void Start()
    {
        /// Base class initialisation
        sprRend = GetComponent<SpriteRenderer>();

        health = 100;
        atkSpeed = 2.0f;

        speed = 3;
        atk = 20;
        defense = 0;

        /// This class initialisation
        player = GameObject.FindGameObjectWithTag("Player");
        entityAttack = GetComponent<EntityAttack>();
        originalPos = transform.position;

        CurrState = InitialState;

        atkTimer = 0.0f;
        colorTime = 0.2f;
        colorTimer = colorTime;

        expValue = 100;
    }

    void Update()
    {
        CheckDeath();

        if (IsFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }

        switch (CurrState)
        {
            case EnemyState.ROAM:
                Roam();
                break;
            case EnemyState.GUARD:
                Guard();
                break;
            case EnemyState.CHASE:
                Chase();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
        }

        // TEMPORARY: CHANGE COLOR FOR A SHORT TIME AFTER HIT
        if (sprRend.color == new Color(255f, 0.0f, 0.0f, 255f) && colorTimer > 0)
        {
            colorTimer -= Time.deltaTime;
        }
        else if (sprRend.color == new Color(255f, 0.0f, 0.0f, 255f) && colorTimer <= 0)
        {
            colorTimer = colorTime;
            sprRend.color = new Color(255f, 255f, 255f, 255f);
        }

    }

    // a method to handle enemy roaming
    protected void Roam()
    {
        hit = Physics2D.Raycast(transform.position, currDir, 5.0f, playerLayer);

        if (hit)
        {
            player = hit.transform.gameObject;
            CurrState = EnemyState.CHASE;
            return;
        }

        if (Mathf.Abs(originalPos.x - transform.position.x) >= 3.0f)
        {
            IsFacingRight = !IsFacingRight;
        }

        Move();
    }

    // a method to handle enemy static guard
    protected void Guard()
    {
        hit = Physics2D.Raycast(transform.position, currDir, 5.0f, playerLayer);

        if (hit)
        {
            player = hit.transform.gameObject;
            CurrState = EnemyState.CHASE;
            return;
        }
    }

    // a method to handle enemy chasing
    protected void Chase()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 1.0f)
        {
            CurrState = EnemyState.ATTACK;
            return;
        }
        else if (distance > 5.0f)
        {
            CurrState = InitialState;
            return;
        }
        else
        {
            if (player.transform.position.x < transform.position.x)
            {
                IsFacingRight = false;
            }
            else
            {
                isFacingRight = true;
            }
            Move();
        }
    }

    // a method to handle enemy attacking
    protected void Attack()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > 1.0f)
        {
            CurrState = EnemyState.CHASE;
            return;
        }
        else
        {
            if (atkTimer <= 0.0f)
            {
                atkTimer = atkSpeed;
                entityAttack.Attack(Atk);
            }
            else
            {
                atkTimer -= Time.deltaTime;
            }
        }
    }

    // a method to handle enemy taking damage
    public override void TakeDamage(float atk)
    {
        base.TakeDamage(atk);
        sprRend.color = new Color(255f, 0.0f, 0.0f, 255f);
    }

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
