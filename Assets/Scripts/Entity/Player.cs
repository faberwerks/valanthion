using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected EntityAttack entityAttack;
    protected Weapon weapon;
    protected SkillAttack skillAttack;
    protected Inventory inv;

    protected Vector2 jumpForce = new Vector2(0, 1);
    protected Vector2 dashDir;

    public float stamina;

    protected int jumpPower;
    protected int exp;
    protected float range;

    protected bool isJumping;
    protected bool canDoubleJump;
    private bool hasDied = false;

    private void Awake()
    {
        Weapon = GetComponent<Weapon>();
    }

    // Use this for initialization
    void Start()
    {
        // base class initialisation
        rb = gameObject.GetComponent<Rigidbody2D>();

        health = 100;

        speed = 5;

        // this class initialisation
        entityAttack = GetComponent<EntityAttack>();
        skillAttack = GetComponent<SkillAttack>();
        inv = GetComponent<Inventory>();

        stamina = 100;

        jumpPower = 5;
        exp = 0;

        isJumping = false;

        atk = weapon.Atk;
        range = weapon.Range;
        entityAttack.AtkCooldown = weapon.AtkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        InputAttack();
        CheckDeath();
        Jump();
        InputMove();
        Stamina += 10 * Time.deltaTime; // stamina regen
        InputSkill();
        InputInv();
        Dash();
    }

    // a method to validate death
    protected override void CheckDeath()
    {
        if (Health <= 0 && !hasDied)
        {
            GameManager.Instance.Defeat(true);
            hasDied = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    /////// INPUT METHODS ///////
    // a method to player input for movement
    public void InputMove()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            IsFacingRight = true;
            Move();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            IsFacingRight = false;
            Move();
        }
    }

    // a method to handle skill use input
    public void InputSkill()
    {
        if (Input.GetKeyDown(KeyCode.A) && stamina >= 30.0f)
        {
            skillAttack.SkillA(atk);
        }
    }

    // a method to handle player jump
    // REMINDER: Set fixed jump stamina cost
    void Jump()
    {
        if (Input.GetKeyDown("up"))
        {
            if (!isJumping && stamina >=10)
            {
                rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                canDoubleJump = true;
                isJumping = true;
                stamina -= 10;
            }
            else
            {
                if (canDoubleJump && stamina >= 10)
                {
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                    stamina -= 10;
                }
            }
        }
    }

    // a method to handle input for attacks
    public bool InputAttack()
    {
        if (Input.GetKeyDown("z"))
        {
            // Debug.Log("Weapon Type: " +  weapon.WeaponType);
            // Debug.Log("Attack Strength: " + atk);
            entityAttack.Attack(Atk,range);
        }
        return false;
    }

    // a method to handle input for inventory
    public void InputInv()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inv.items[0].count > 0)
            {
                Health += inv.items[0].value;
                inv.RemoveItem("Health Potion");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inv.items[0].count > 0)
            {
                Stamina += inv.items[0].value;
                inv.RemoveItem("Stamina Potion");
            }
        }
    }

    // a method to handle dashing
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Stamina >= 20)
        {
            if (IsFacingRight)
            {
                dashDir = new Vector2(1, 0);
            }
            else
            {
                dashDir = new Vector2(-1, 0);
            }
            rb.AddForce(dashDir * 4, ForceMode2D.Impulse);
            Stamina -= 20;
        }
    }

    /////// PROPERTIES ///////
    public Weapon Weapon
    {
        get
        {
            return weapon;
        }
        set
        {
            this.weapon = value;
        }
    }

    public int Exp
    {
        get
        {
            return exp;
        }
        set
        {
            this.exp += value;
        }
    }

    public float Stamina
    {
        get
        {
            return stamina;
        }
        set
        {
            if(stamina >= 100)
            {
                stamina = 100;
            }
            else if (stamina <= 0)
            {
                stamina = 0;
            }
            else
            {
                this.stamina = value;
            }
        }
    }

    public bool IsJumping
    {
        get
        {
            return isJumping;
        }
        set
        {
            this.isJumping = value;
        }
    }

}
