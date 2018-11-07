using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour {

    private Entity entity;

    public LayerMask targetLayer;

    private Vector2 currDir;

    private float attackTimer = 0;
    private float attackCd = 0.5f;

    private bool isAttacking = false;

    private void Start()
    {
        entity = GetComponentInParent<Entity>();
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

        if (Input.GetKeyDown("z") && !isAttacking)
        {
            Attack();
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
            }
        }
    }

    public void Attack()
    {
        isAttacking = true;
        attackTimer = attackCd;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);
        if (hit)
        {
            hit.transform.gameObject.GetComponent<Entity>().TakeDamage(entity.Atk);
        }
    }
}
