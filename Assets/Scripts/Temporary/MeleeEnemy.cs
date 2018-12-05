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

        health = 100;
        atkSpeed = 2.0f;

        range = weapon.AtkRange;
        speed = 3;
        atk = weapon.Atk;
        defense = 10;

        /// This class initialisation
        player = GameObject.FindGameObjectWithTag("Player");
        entityAttack = GetComponent<EntityAttack>();
        originalPos = transform.position;

        CurrState = InitialState;

        entityAttack.AtkCooldown = weapon.AtkSpeed;
        colorTime = 0.2f;
        colorTimer = colorTime;

        ExpValue = 100;
    }
	
	// Update is called once per frame
	void Update () {
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

    public void Patrol()
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

    public void Guard()
    {
        hit = Physics2D.Raycast(transform.position, currDir, 5.0f, playerLayer);

        if (hit)
        {
            player = hit.transform.gameObject;
            CurrState = EnemyState.CHASE;
            return;
        }
    }

    public void Chase()
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

    public void Attack()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > 1.0f)
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
