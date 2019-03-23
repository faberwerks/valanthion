using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy, IEnemy {

    protected EntityAttack entityAttack;

    protected RaycastHit2D hit;

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

        health = 100;
        atkSpeed = 2.0f;

        range = weapon.AtkRange;
        speed = (int) maxSpeed;
        atk = weapon.Atk;
        defense = 10;

        /// This class initialisation
        player = GameObject.FindGameObjectWithTag("Player");
        entityAttack = GetComponent<EntityAttack>();
        originalPos = transform.position;

        //remove this later
        initialColor = sprRend.color;

        CurrState = InitialState;

        entityAttack.AtkCooldown = weapon.AtkSpeed;
        colorTime = 0.2f;
        colorTimer = colorTime;

        ExpValue = 100;

        currDir = new Vector2(1, 1);

        /*
        if (IsFacingRight)
        {
            localMove = -1.0f;
        }
        else
        {
            localMove = 1.0f;
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
        CheckDeath();

        //if (IsFacingRight)
        //{
        //    currDir = Vector2.right;
        //}
        //else
        //{
        //    currDir = Vector2.left;
        //}

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

    private void FixedUpdate()
    {
        /*
        switch (CurrState)
        {
            case EnemyState.PATROL:
            case EnemyState.CHASE:
                Move(localMove);
                break;
        }
        */
    }

    // a method to handle melee enemy patrol
    public void Patrol()
    {
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

    // a method to handle melee enemy guarding
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

    // a method to handle melee enemy chasing
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
                // IsFacingRight = !false;
                // Flip();
                Flip(false);
            }
            else if(player.transform.position.x > transform.position.x)
            {
                // IsFacingRight = !true;
                // Flip();
                Flip(true);
            }
            Move();
        }
    }

    // a method to handle melee enemy attack
    public void Attack()
    {
        anim.SetFloat("Speed", 0.0f);

        #region edited by :
        // Changed made by : Samuel Edsel Fernandez
        // Edited 23 mar 2019
        // Purpose :Make the AI detect which deretion he need to facing when attacking
        #endregion

        #region Comented
        //distance = Mathf.Abs(transform.position.x - player.transform.position.x);
        //if (distance > range)
        //{
        //    CurrState = EnemyState.CHASE;
        //    return;
        //}
        //else
        //{
        //    if (!entityAttack.IsAttacking)
        //    {
        //        entityAttack.Attack(Atk, range);
        //    }
        //}
        #endregion

        distance = transform.position.x - player.transform.position.x;

        #region Explanation
        //if distance is minus than the player is at left
        //The isFacingRight variable is flipped so if isFacingRight == true the enemy will facing left
        #endregion

        if(distance < 0 && isFacingRight == false && distance < range)
        {
            Debug.Log("Player at the left");
            Flip();
        }
        else if(distance > 0 && isFacingRight == true && distance < range)
        {
            Debug.Log("Player at the right");
            Flip();
        }

        if (Mathf.Abs(distance) > range)
        {
            CurrState = EnemyState.CHASE;
            return;
        }
        else
        {
            if (!entityAttack.IsAttacking)
            {
                entityAttack.Attack(Atk, range);
            }
        }

    }

    public void Retreat() { }
}
