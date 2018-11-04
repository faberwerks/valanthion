using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public GameManager gameManager;

    protected Vector2 jumpForce = new Vector2(0, 1);

    public float stamina;

    protected int jumpPower;
    protected int exp;

    protected bool isJumping;
    protected bool canDoubleJump;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isJumping = false;
        jumpPower = 5;
        speed = 5;
        health = 100;
        exp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        Jump();
        Skill();
        InputMove();
    }

    // a method to validate death
    public void CheckDeath()
    {
        if (Health <= 0)
        {
            gameManager.CurrState = GameManager.GameState.DEFEAT;
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

    // a method to handle skills
    void Skill()
    {
        if (Input.GetKeyDown("q"))
        {
            Debug.Log("skill q");
        }

        if (Input.GetKeyDown("w"))
        {
            Debug.Log("skill w");
        }

        if (Input.GetKeyDown("e"))
        {
            Debug.Log("skill e");
        }

        if (Input.GetKeyDown("r"))
        {
            Debug.Log("skill r");
        }

        if (Input.GetKeyDown("s"))
        {
            Debug.Log("skill s");
        }

        if (Input.GetKeyDown("t"))
        {
            Debug.Log("skill t");
        }

        if (Input.GetKeyDown("y"))
        {
            Debug.Log("skill y");
        }
    }

    // a method to handle player jump
    void Jump()
    {
        if (Input.GetKeyDown("up"))
        {
            if (!isJumping)
            {
                rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                canDoubleJump = true;
                isJumping = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    /////// PROPERTIES ///////
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
    }

}
