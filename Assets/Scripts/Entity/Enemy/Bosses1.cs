using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses1 : Enemy, IEnemy
{
    protected EntityAttack entityAttack;

    protected RaycastHit2D hit;

    #region primitiveVariable
        private int atkCount;

        // this variable control attack delay between combo
        public float comboDelay;

        // this variable control the attack delay
        public float attackDelay;
        //this variable control how long the delay before the boss perform skill
        public float skillDelay = 11;
        //this variable use to multiply the skill damage
        public float skillMultiplier = 2;

        private float attackCd;
        private float comboCd;
        private float skillCounter;

        private bool isAttacking;

        private bool isCoolingDown = false;
    #endregion

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

        #region StatInit
            atkCount = 0;
            comboDelay = 0.5f;
            health = 100;
            atkSpeed = 2.0f;
            attackDelay = atkSpeed;

            skillCounter = 0;
            attackCd = 0;
            atkCount = 0;

            range = weapon.AtkRange;
            speed = (int)maxSpeed;
            atk = weapon.Atk;
            defense = 10;
        #endregion 

        /// This class initialisation
        player = GameObject.FindGameObjectWithTag("Player");
        entityAttack = GetComponent<EntityAttack>();
        originalPos = transform.position;

        CurrState = InitialState;

        #region Color
            colorTime = 0.2f;
            colorTimer = colorTime;
            initialColor = sprRend.color;
        #endregion

        ExpValue = 100;

        currDir = new Vector2(1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        // ResetCombo();
        ComboDelay();
        Skill();

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
            if (atkCount < 3)
            {
                // Debug.Log("COMBO ATTACK!");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, range, playerLayer);
                atkCount += 1;
                isAttacking = true;
                comboCd = comboDelay;
                if (hit)
                {
                    hit.collider.SendMessage("TakeDamage", atk);
                }
            }
            else
            {
                // Debug.Log(isCoolingDown);
                if (!isCoolingDown)
                {
                    attackCd = attackDelay;
                    isCoolingDown = true;
                    StartCoroutine(CResetCombo());
                    // Debug.Log("IS COOLING DOWN TRUE");
                }
            }
        }
    }

    //this function is used to make the boss could do the combo again
    public void ResetCombo()
    {
        if(attackCd > 0 && atkCount == 3)
        {
            // Debug.Log(attackCd);
            attackCd -= Time.deltaTime;
            if(attackCd <= 0)
            {
                // Debug.Log("1 step before reset !!");
                attackCd = -1;
            }
        }
        else if(attackCd < 0 && atkCount == 3)
        {
            // Debug.Log("Reseted !!!");
            atkCount = 0;
            isCoolingDown = false;
        }
    }

    // a coroutine to count down boss' combo reset
    public IEnumerator CResetCombo()
    {
        while (attackCd > 0 && atkCount == 3)
        {
            // Debug.Log(attackCd);
            attackCd -= Time.deltaTime;
            if (attackCd <= 0)
            {
                attackCd = -1;
            }
            yield return 0;
        }
        if (attackCd < 0 && atkCount == 3)
        {
            // Debug.Log("Reseted !!!");
            atkCount = 0;
            isCoolingDown = false;
            yield break;
        }
    }

    // this function is used to control the delay between combo attack
    public void ComboDelay()
    {
        if (isAttacking)
        {
            if (comboCd > 0)
            {
                comboCd -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
            }
        }
    }

    public void Skill()
    {
        if(skillCounter == skillDelay)
        {
            //Debug.Log("skill active");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, range, playerLayer);
            if (hit)
            {
                hit.collider.SendMessage("TakeDamage", atk * skillMultiplier * 2);
            }
            skillCounter = 0;
        }
        else
        {
            skillCounter += 1;
            //Debug.Log(skillCounter);
        }
    }

    protected override void CheckDeath()
    {
        if (Health <= 0)
        {
           
            Debug.Log("MATI!!!!!");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void Retreat() { }
}
