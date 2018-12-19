using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private Vector2 currDir;

    private float atkTimer = 0;
    private float atkCooldown;

    private bool isAttacking = false;

    private void Start()
    {
        
    }

    private void Update()
    {

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
    public void Fire(Quaternion dir, Transform target)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            atkTimer = atkCooldown;

            GameObject obj = ObjectPooler.current.GetPooledObject();

            obj.transform.position = transform.position;
            obj.transform.rotation = dir;
            obj.GetComponent<ArrowBehavior>().CurrDir = new Vector2(target.position.x, target.position.y);
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
