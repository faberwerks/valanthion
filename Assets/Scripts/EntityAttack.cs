using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour {

    private Entity entity;

    public LayerMask targetLayer;

    private Vector2 currDir;

    private float atkTimer = 0;
    private float atkCd = 0.5f;

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
    public void Attack(float atk, float range)
    {
        isAttacking = true;
        atkTimer = atkCd;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir,range, targetLayer);
        if (hit)
        {
            hit.transform.gameObject.GetComponent<Entity>().TakeDamage(atk);
        }
    }
}
