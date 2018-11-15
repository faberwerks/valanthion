using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private EntityAttack entityAttack;

    protected Vector2 jumpForce = new Vector2(0, 1);

    protected Weapon weapon;
    protected SkillAttack skillAttack;

    public float stamina;

    protected int jumpPower;
    protected int exp;

    protected bool isJumping;
    protected bool canDoubleJump;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        entityAttack = GetComponent<EntityAttack>();
        Weapon = GetComponent<Weapon>();
        skillAttack = GetComponent<SkillAttack>();
        Debug.Log("ATTACK: " + weapon.Attack);
        isJumping = false;
        jumpPower = 5;
        speed = 5;
        health = 100;
        stamina = 100;
        exp = 0;
        atk = weapon.Attack;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("PLAYER HEALTH: " + Health);
        InputAttack();
        CheckDeath();
        Jump();
        InputMove();
        Stamina += 10 *Time.deltaTime;
        InputSkill();
    }

    // a method to validate death
    protected override void CheckDeath()
    {
        if (Health <= 0)
        {
            GameManager.Instance.Defeat(true);
        }
    }

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

    public void InputSkill()
    {
                if (Input.GetKeyDown(KeyCode.A) && stamina >= 30.0f)
                {
                    Debug.Log("SUPER SAIYAN SWORD SKILL 1");
                    skillAttack.SkillA(atk);
                }

                if (Input.GetKeyDown(KeyCode.A) && stamina >= 30.0f)
                {
                    Debug.Log("SUPER SAIYAN AXE SKILL 1");
                    skillAttack.SkillA(atk);
                }
    }

    // a method to handle player jump
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
            Debug.Log("Weapon Type: " +  weapon.WeaponType);
            Debug.Log("Attack Strength: " + atk);
            entityAttack.Attack(Atk);
        }
        return false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
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

}
