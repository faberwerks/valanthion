using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour {

    public AudioClip atkSound;

    public AudioSource audioSource;

    private Animator anim;

    private Entity entity;

    public LayerMask targetLayer;

    private Vector2 currDir;

    private float atkTimer = 0;
    private float atkCooldown;

    private bool isAttacking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();

        entity = GetComponent<Entity>();

        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (entity.IsFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }

        if (isAttacking)
        {
            if (atkTimer > 0)
            {
                atkTimer -= Time.deltaTime;
                
            }
            else
            {
                isAttacking = false;
            }
        }
    }

    // a method to handle entity attacks
    public virtual void Attack(float atk, float range)
    {
        if (!isAttacking)
        {
            anim.SetBool("Is Attacking", true);
            audioSource.PlayOneShot(atkSound);
            isAttacking = true;
            
            atkTimer = atkCooldown;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, range, targetLayer);
            if (hit)
            {
                hit.collider.SendMessage("TakeDamage", atk);
            }
        }
    }

    /////// PROPERTIES ///////
    public float AtkCooldown
    {
        get
        {
            return atkCooldown;
        }
        set
        {
            this.atkCooldown = value;
        }
    }

    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }
        set
        {
            this.isAttacking = value;
        }
    }
}
