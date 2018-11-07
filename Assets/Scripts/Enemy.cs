using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public enum EnemyState : byte { ROAM, GUARD, CHASE, ATTACK };

    private GameObject player;

    private EntityAttack entityAttack;

    private RaycastHit2D hit;

    protected Vector3 originalPos;

    protected Vector2 currDir;

    protected EnemyState initialState;
    protected EnemyState currState;

    protected float attackTimer;
    protected float yMin;
    private float distance;

    protected int expValue;
    private int playerLayer;

    private void Awake()
    {
        playerLayer = LayerMask.GetMask("Player");
    }

    void Start()
    {
        originalPos = transform.position;
        health = 100;
        speed = 3;
        atk = 20;
        defense = 0;

        atkSpeed = 2.0f;
        attackTimer = 0.0f;

        player = GameObject.FindGameObjectWithTag("Player");
        entityAttack = GetComponent<EntityAttack>();

        expValue = 100;

        CurrState = InitialState;
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
                break;
            case EnemyState.CHASE:
                Chase();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
        }

        Debug.Log(CurrState);
        Debug.Log("ENEMY HEALTH: " + Health);
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
            Debug.Log("ATTACK: TOO FAR");
            CurrState = EnemyState.CHASE;
            return;
        }
        else
        {
            if (attackTimer <= 0.0f)
            {
                Debug.Log("ATTACK: ATTACKING");
                attackTimer = atkSpeed;
                entityAttack.Attack(Atk);
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }
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
