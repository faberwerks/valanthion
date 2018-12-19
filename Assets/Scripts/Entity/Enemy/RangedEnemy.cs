using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy, IEnemy {

    protected RangedAttack rangedAttack;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        playerLayer = LayerMask.GetMask("Player");
    }

    // Use this for initialization
    void Start () {
        /// Base class initialisation
        sprRend = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //remove this later
        initialColor = sprRend.color;

        health = 100;
        atkSpeed = 2.0f;

        range = weapon.AtkRange;
        speed = 3;
        atk = weapon.Atk;
        defense = 10;

        /// This class initialisation
        player = GameObject.FindGameObjectWithTag("Player");
        rangedAttack = GetComponent<RangedAttack>();
        originalPos = transform.position;

        CurrState = InitialState;

        rangedAttack.AtkCooldown = weapon.AtkSpeed;
        colorTime = 0.2f;
        colorTimer = colorTime;

        ExpValue = 100;
    }
	
	// Update is called once per frame
	void Update () {
        CheckDeath();

        /*
        if (IsFacingRight)
        {
            localMove = 1.0f;
            currDir = Vector2.right;
        }
        else
        {
            localMove = -1.0f;
            currDir = Vector2.left;
        }
        */
        currDir = new Vector2(1, 1);

        Debug.Log(CurrState);
        switch (CurrState)
        {
            case EnemyState.PATROL:
                Patrol();
                break;
            case EnemyState.GUARD:
                Guard();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
            case EnemyState.RETREAT:
                Retreat();
                break;
        }
    }

    // a method to handle ranged enemy patrol
    public void Patrol()
    {
        Collider2D[] target = Physics2D.OverlapBoxAll(transform.position, currDir * detectionRange, 0, playerLayer);

        if (target.Length > 0)
        {
            player = target[0].gameObject;
            CurrState = EnemyState.ATTACK;
            return;
        }

        if (Mathf.Abs(originalPos.x - transform.position.x) >= 3.0f)
        {
            Flip();
        }

        Move();
    }

    // a method to handle ranged enemy guarding
    public void Guard()
    {
        anim.SetFloat("Speed", 0);

        Collider2D[] target = Physics2D.OverlapBoxAll(transform.position, currDir * detectionRange, 0, playerLayer);

        if (target.Length > 0)
        {
            player = target[0].gameObject;
            CurrState = EnemyState.ATTACK;
            return;
        }
    }

    // a method to handle ranged enemy attack
    public void Attack()
    {
        anim.SetFloat("Speed", 0);

        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > detectionRange)
        {
            CurrState = InitialState;
            return;
        }
        else if (distance < 3.0f)
        {
            CurrState = EnemyState.RETREAT;
            return;
        }
        else
        {

            if (!rangedAttack.IsAttacking)
            {
                rangedAttack.Fire(FindArrowDir(), player.transform);
            }
        }
    }

    // a method to handle ranged enemy retreat
    public void Retreat()
    {
        /*
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 3.0f)
        {
            if (player.GetComponent<Player>().IsFacingRight)
            {
                localMove = 1.0f;
            }
            else
            {
                localMove = -1.0f;
            }

            Move(localMove);
        }
        else
        {
            CurrState = EnemyState.ATTACK;
            return;
        }
        */

        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 3.0f)
        {
            if (player.transform.position.x > transform.position.x)
            {
                Flip(false);
            }
            else
            {
                Flip(true);
            }

            Move();
        }
        else
        {
            CurrState = EnemyState.ATTACK;
            return;
        }
    }

    public void Chase() { }

    // a method to determine the direction of the shot arrow
    private Quaternion FindArrowDir()
    {
        /*
        Vector2 dir;

        float x = player.transform.position.x - transform.position.x;

        float y = player.transform.position.y - transform.position.y;

        dir = new Vector2(x, y);
        */
        Vector3 targ = player.transform.position;

        targ.z = 0;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

        Quaternion dir = Quaternion.Euler(new Vector3(0, 0, angle));
        return dir;
    }
}
