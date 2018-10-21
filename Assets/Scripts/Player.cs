using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public GameManager gameManager;

    protected Vector2 jumpForce = new Vector2(0, 1);

    public float stamina;

    protected bool isJumping;
    protected bool canDoubleJump;

    protected int jumpPower;
    protected int exp;

    [SerializeField]
    private void Awake()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    // this function is use for death validation
    void CheckDeath()
    {
        if (GetHealth() <= 0)
        {
            gameManager.SetState((byte)GameManager.GameState.Defeat);
        }
    }

    // this function is use to move the character
    void KeyDown()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {
            SetIsFacingRight(true);
            Move();
        }
        
        else if (Input.GetAxis("Horizontal") < 0)
        {
            SetIsFacingRight(false);
            Move();
        }

    }

    //this function 
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
        KeyDown();
        Debug.Log(exp);
    }

    public int GetExp()
    {
        return this.exp;
    }

    public void SetExp(int expValue)
    {
        this.exp+=expValue;
    }

    public float GetStamina()
    {
        return stamina;
    }

}
