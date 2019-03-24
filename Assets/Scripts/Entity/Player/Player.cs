using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public AudioClip jumpSound;
    public AudioClip drinkSound;
    public AudioClip injuredSound;

    public AudioSource audioSource;

    protected EntityAttack entityAttack;
    protected Weapon weapon;
    protected Armor armor;
    protected SkillControl skillControl;
    protected Inventory inv;
    protected MenuManager menuManager;

    protected Vector2 jumpForce = new Vector2(0, 1);

    public float stamina;

    public int jumpPower;
    protected int exp;
    protected float range;

    protected bool isJumping;
    protected bool canDoubleJump;
    private bool hasDied = false;

    private void Awake()
    {
        Weapon = GetComponent<Weapon>();
        armor = GetComponent<Armor>();
    }

    // Use this for initialization
    void Start()
    {
        // base class initialisation
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();

        //remove this later
        initialColor = sprRend.color;

        maxHealth = 100;
        health = maxHealth;

        speed = 5;

        colorTime = 0.2f;
        colorTimer = colorTime;

        // this class initialisation
        entityAttack = GetComponent<EntityAttack>();
        skillControl = GetComponent<SkillControl>();
        inv = GetComponent<Inventory>();
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();

        maxStamina = 100;
        stamina = maxStamina;

        exp = 0;

        isJumping = false;

        atk = weapon.Atk;
        range = weapon.AtkRange;
        entityAttack.AtkCooldown = weapon.AtkSpeed;
        Defense = armor.Defense;

        LayerMask enemyLayer = LayerMask.GetMask("Enemy");
        LayerMask obstacleLayer = LayerMask.GetMask("Obstacle");
        LayerMask targetLayer = enemyLayer | obstacleLayer;

        entityAttack.targetLayer = targetLayer;

    }

    // Update is called once per frame
    void Update()
    {
        InputAttack();
        CheckDeath();
        if (!menuManager.minimapIsOpen)
        {
            Jump();
            InputMove();
        }
        Stamina += 10 * Time.deltaTime; // stamina regen
        InputSkill();
        InputInv();
        InputDash();
    }

    // a method to validate death
    protected override void CheckDeath()
    {
        if (Health <= 0 && !hasDied)
        {
            GameManager.Instance.Defeat();
            hasDied = true;
        }
    }

    // a method to handle dashing
    public void Dash()
    {
        Vector2 dashDir;
        if (IsFacingRight)
        {
            dashDir = Vector2.right;
        }
        else
        {
            dashDir = Vector2.left;
        }
        rb.AddForce(dashDir * 4, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            anim.SetBool("Is Jumping", false);
            anim.SetBool("Is Double Jumping", false);
        }
    }

    /////// INPUT METHODS ///////
    // a method to player input for movement
    public void InputMove()
    {
        float tempMove = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Tab))
        {
            tempMove = 0;
        }
        Move(tempMove);

    }

    // a method to handle skill use input
    public void InputSkill()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            skillControl.UseSkill(InputManager.instance.AKeySkill);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            skillControl.UseSkill(InputManager.instance.SKeySkill);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            skillControl.UseSkill(InputManager.instance.DKeySkill);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            skillControl.UseSkill(InputManager.instance.FKeySkill);
        }
    }

    // a method to handle player jump
    // REMINDER: Set fixed jump stamina cost
    void Jump()
    {
        if (Input.GetKeyDown("up") && !Input.GetKey(KeyCode.Tab))
        {
            if (!isJumping && stamina >=10)
            {
                rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                canDoubleJump = true;
                isJumping = true;
                anim.SetBool("Is Jumping", true);
                stamina -= 10;
                audioSource.PlayOneShot(jumpSound);

            }
            else
            {
                if (canDoubleJump && stamina >= 10)
                {
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                    anim.SetBool("Is Double Jumping", true);
                    stamina -= 10;
                    audioSource.PlayOneShot(jumpSound);
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
            if (inv.items[1].count > 0)
            {
                Stamina += inv.items[1].value;
                inv.RemoveItem("Stamina Potion");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inv.items[2].count > 0)
            {
                atk += inv.items[2].value;
                inv.RemoveItem("Attack Potion");
                Debug.Log("Damage Buff :" + atk);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (inv.items[3].count > 0)
            {
                defense += inv.items[3].value;
                inv.RemoveItem("Defense Potion");
                Debug.Log("Defense Buff :" + defense);
            }
        }
    }

    // a method to handle dashing input
    public void InputDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Stamina >= 20)
        {
            Dash();
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
            if(stamina > 100)
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

    public bool HasDied
    {
        get
        {
            return hasDied;
        }
        set
        {
            this.hasDied = value;
        }
    }

}
