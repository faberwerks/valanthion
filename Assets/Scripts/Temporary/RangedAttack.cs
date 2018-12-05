using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private Entity entity;

    private Vector2 currDir;

    private float atkTimer = 0;
    private float atkCooldown;

    private bool isAttacking = false;

    private void Start()
    {
        entity = GetComponent<Entity>();
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
    public virtual void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            atkTimer = atkCooldown;

            GameObject obj = ObjectPooler.current.GetPooledObject();

            obj.transform.position = transform.position;
            obj.GetComponent<ArrowBehavior>().CurrDir = currDir;
            obj.SetActive(true);
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
