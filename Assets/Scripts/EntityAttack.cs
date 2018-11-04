using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour {

    private bool isAttacking = false;

    private Entity entity;
    private float attackTimer = 0;
    private float attackCd = 0.5f;

    //public Collider2D attackTriggerLeft;
    //public Collider2D attackTriggerRight;
    //private Collider2D attackTrigger;

    private void Awake()
    {
        //attackTriggerLeft.enabled = false;
        //attackTriggerRight.enabled = false;
    }

    private void Start()
    {
        entity = GetComponentInParent<Entity>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("z") && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCd;

            if (entity.IsFacingRight)
            {
                //attackTrigger = attackTriggerRight;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 10.0f, LayerMask.GetMask("Enemy"));
                hit.transform.gameObject.GetComponent<Enemy>().Damage(100);
            }
            else
            {
                //attackTrigger = attackTriggerLeft;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 10.0f, LayerMask.GetMask("Enemy"));
                hit.transform.gameObject.GetComponent<Enemy>().Damage(100);
            }

            //attackTrigger.enabled = true;
        }

        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                //attackTrigger.enabled = false;
            }
        }
    }
}
