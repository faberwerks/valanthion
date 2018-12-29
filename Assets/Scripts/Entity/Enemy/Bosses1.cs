using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses1 : Enemy, IEnemy
{
    protected EntityAttack entityAttack;

    protected RaycastHit2D hit;

    private LayerMask targetLayer;

    private int atkCount;

    // this variable control attack delay between combo
    public float comboDelay;

    // this variable control the attack delay
    public float attackDelay;

    private bool isAttacking;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        playerLayer = LayerMask.GetMask("Player");
    }

    // Use this for initialization
    void Start()
    {
        /// Base class initialisation
        sprRend = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        atkCount = 0;
        comboDelay = 0.5f;
        health = 100;
        atkSpeed = 2.0f;

        range = weapon.AtkRange;
        speed = (int)maxSpeed;
        atk = weapon.Atk;
        defense = 10;

        /// This class initialisation
        player = GameObject.FindGameObjectWithTag("Player");
        entityAttack = GetComponent<EntityAttack>();
        originalPos = transform.position;

        CurrState = InitialState;

        colorTime = 0.2f;
        colorTimer = colorTime;

        ExpValue = 100;

        currDir = new Vector2(1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        ResetCombo();
        ComboDelay();

        switch (CurrState)
        {
            case EnemyState.PATROL:
                Patrol();
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
    }

    // a method to handle bosses patrol
    public void Patrol()
    {
        Debug.Log("patrolling");
        Collider2D[] target = Physics2D.OverlapBoxAll(transform.position, currDir * detectionRange, 0, playerLayer);

        if (target.Length > 0)
        {
            player = target[0].gameObject;
            CurrState = EnemyState.CHASE;
            return;
        }

        if (Mathf.Abs(originalPos.x - transform.position.x) >= 3.0f)
        {
            Flip();
        }

        Move();
    }

    public void Rage()
    {
        if(health <= (health * 0.25))
        {
            maxSpeed += 1;
            defense -= 1;

        }
    }

    // a method to handle bosses guarding
    public void Guard()
    {
        anim.SetFloat("Speed", 0.0f);

        Collider2D[] target = Physics2D.OverlapBoxAll(transform.position, currDir * detectionRange, 0, playerLayer);

        if (target.Length > 0)
        {
            player = target[0].gameObject;
            CurrState = EnemyState.CHASE;
            return;
        }
    }

    // a method to handle bosses chasing
    public void Chase()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= range)
        {
            CurrState = EnemyState.ATTACK;
            return;
        }
        else if (distance > detectionRange)
        {
            CurrState = InitialState;
            originalPos = transform.position;
            return;
        }
        else
        {
            if (player.transform.position.x < transform.position.x)
            {
                Flip(false);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                Flip(true);
            }
            Move();
        }
    }

    // a method to handle bosses attack
    public void Attack()
    {
        anim.SetFloat("Speed", 0.0f);

        distance = Mathf.Abs(transform.position.x - player.transform.position.x);
        if (distance > range)
        {
            CurrState = EnemyState.CHASE;
            return;
        }
        else
        {
            if (atkCount < 3 && isAttacking == false)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, range, playerLayer);
                if (hit)
                {
                    hit.collider.SendMessage("TakeDamage", atk);
                }
            }
        }
    }

    //this function is used to make the boss could do the combo again
    public void ResetCombo()
    {
        if(atkCount == 3)
        {
            if(attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
            }
            else
            {
                atkCount = 0;
            }
        }
    }

    // this function is used to control the delay between combo attack
    public void ComboDelay()
    {
        if (isAttacking)
        {
            if (comboDelay > 0)
            {
                comboDelay -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
            }
        }
    }

    public void Retreat() { }
}
