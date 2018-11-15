using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour {

    private Player player;

    public LayerMask targetLayer;

    private Vector2 currDir;

    private Weapon.WeaponTypes weaponType;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        weaponType = player.Weapon.WeaponType;
	}

    // Update is called once per frame
    private void Update()
    {
        if (player.IsFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }
    }

    public void SkillA(int atk)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);
        switch(weaponType)
        {
            case Weapon.WeaponTypes.SWORD:

                if (hit)
                {
                    hit.transform.gameObject.GetComponent<Entity>().TakeDamage(atk * 1.2f);
                }
               break;

            case Weapon.WeaponTypes.AXE:

                if (hit)
                {
                    hit.transform.gameObject.GetComponent<Entity>().TakeDamage(atk * 1.5f);
                }
                break;

            case Weapon.WeaponTypes.SPEAR:
                if (hit)
                {
                    hit.transform.gameObject.GetComponent<Entity>().TakeDamage(atk * 1.1f);
                }
                break;
        }
    }
}
