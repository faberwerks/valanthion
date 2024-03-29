﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour {

    private Player player;

    private SkillProcessor skillProcessor;

    private Weapon weapon;

    private Vector2 currDir;

    public LayerMask targetLayer;

    public bool[] canUse = new bool[6];
    public float[] cooldownTimers = new float[6];

    private float weaponDamage;
    private float weaponRange;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();

        skillProcessor = GetComponent<SkillProcessor>();

        weapon = GetComponent<Weapon>();

        for (int i = 0; i < 6; i++)
        {
            canUse[i] = true;
        }

        weaponDamage = weapon.Atk;
        weaponRange = weapon.AtkRange;
	}

	// Update is called once per frame
	void Update () {
		if (player.IsFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }
	}

    // a method to execute skills based on skill number
    public void UseSkill(byte skillNumber)
    {
        Skill skill = skillProcessor.GetSkill(skillNumber);

        if (skill == null)
        {
            Debug.Log("Skill soesn't exist");
            return;
        }

        #region Commented: Bug #049
        //if (skill.staminaCost > 0 && player.Stamina >= skill.staminaCost)
        //{
        //    player.Stamina -= skill.staminaCost;
        //}
        //else
        //{
        //    Debug.Log("Stamina not enough");
        //    return;
        //}

        //if (cooldownTimers[skillNumber] > 0)
        //{
        //    Debug.Log("Sedang cooldown");
        //    return;
        //}
        //else
        //{
        //    cooldownTimers[skillNumber] = skill.cooldownTime;
        //}
        #endregion

        #region Documentation: Bug #049 Fix
        // Bug #049: SkillControl checks first whether there is enough stamina then immediately uses the stamina.
        //           But it does not take into account the cooldown. So if the stamina is enough, it will use
        //           stamina regardless of whether the cooldown has finished or not.
        // Fix     : Return the method if it does not fulfill the stamina AND cooldown conditions.
        //           If it fulfills the conditions, then use stamina.
        #endregion
        if (skill.staminaCost < 0 || player.Stamina < skill.staminaCost || cooldownTimers[skillNumber] > 0)
        {
            return;
        }
        else
        {
            player.Stamina -= skill.staminaCost;
            cooldownTimers[skillNumber] = skill.cooldownTime;
        }


        RaycastHit2D hit;

        // Damage Handling
        if (skill.dealsDamage)
        {
            if (skill.singleTarget)
            {
                hit = Physics2D.Raycast(transform.position, currDir, weaponRange, targetLayer);

                if (hit)
                {
                    hit.collider.SendMessage("TakeDamage", skill.damageMultiplier * weaponDamage);

                    if (skill.bleeding)
                    {
                        hit.collider.SendMessage("Bleed");
                    }
                }
            }
            else if (skill.multipleTargets)
            {
                Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, new Vector2(weaponRange, 1), 0, targetLayer);

                foreach (Collider2D target in targets)
                {
                    target.SendMessage("TakeDamage", skill.damageMultiplier * weaponDamage);

                    if (skill.bleeding)
                    {
                        target.SendMessage("Bleed");
                    }
                }
            }
        }

        


        hit = Physics2D.Raycast(transform.position, currDir, weaponRange, targetLayer);

        if (hit)
        {
            if (skill.reducesDefense)
            {
                hit.collider.SendMessage("ReduceDefense", 5);
            }

            if (skill.slowsDownTarget)
            {
                hit.collider.SendMessage("SlowDown", 1);
            }

            if (skill.stuns)
            {
                hit.collider.SendMessage("Stun");
            }

            if (skill.knocksBack)
            {
                float knockbackForce = 100.0f;

                knockbackForce = player.IsFacingRight ? knockbackForce : knockbackForce * -1;

                hit.collider.SendMessage("Knockback", knockbackForce);
            }

            if (skill.cripples)
            {
                hit.collider.SendMessage("Cripple", 3);
            }
        }

        // The following methods already exist right above this comment
        /*
        // Defense Handling
        if (skill.reducesDefense)
        {
            hit = Physics2D.Raycast(transform.position, currDir, weaponRange, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("ReduceDefense", 5);
            }
        }

        // Slowdown, stun, knockback, cripple
        if (skill.slowsDownTarget)
        {
            hit = Physics2D.Raycast(transform.position, currDir, weaponRange, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("SlowDown", 1);
            }
        }
        if (skill.stuns)
        {
            hit = Physics2D.Raycast(transform.position, currDir, weaponRange, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("Stun");
            }
        }
        if (skill.knocksBack)
        {
            float knockbackForce = 100.0f;

            knockbackForce = player.IsFacingRight ? knockbackForce : knockbackForce * -1;

            hit = Physics2D.Raycast(transform.position, currDir, weaponRange, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("KnockBack", knockbackForce);
            }
        }
        if (skill.cripples)
        {
            hit = Physics2D.Raycast(transform.position, currDir, weaponRange, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("Cripple", 3);
            }
        }
        */


        // Buff handling
        if (skill.buffs)
        {
            BuffInfo buffInfo = new BuffInfo();

            buffInfo.attackStrength = skill.attackStrength;
            buffInfo.attackSpeed = skill.attackSpeed;
            buffInfo.defense = skill.defense;
            buffInfo.additionalHealth = skill.additionalHealth;
            buffInfo.additionalStamina = skill.additionalStamina;

            player.ApplyBuffs(buffInfo);
        }

        // Reset cooldown handling
        if (skill.resetsCooldowns)
        {
            for (int i = 0; i < cooldownTimers.Length; i++)
            {
                cooldownTimers[i] = 0;
            }
        }

        canUse[skillNumber] = false;
        switch(skillNumber)
        {
            case 0:
                player.GetComponent<Animator>().SetTrigger("Is Using Skill 0");
                break;
            case 1:
                player.GetComponent<Animator>().SetTrigger("Is Using Skill 1");
                break;
            case 2:
                player.GetComponent<Animator>().SetTrigger("Is Using Skill 2");
                break;
            case 3:
                player.GetComponent<Animator>().SetTrigger("Is Using Skill 3");
                break;
            case 4:
                player.GetComponent<Animator>().SetTrigger("Is Using Skill 4");
                break;
            case 5:
                player.GetComponent<Animator>().SetTrigger("Is Using Skill 5");
                break;
        }
        // Dash handling
        if (skill.dashes)
        {
            player.Dash();
        }
        StartCoroutine(CCountdownCooldown(skillNumber));
    }

    /////// COROUTINES ///////
    // a coroutine to countdown skill cooldown
    private IEnumerator CCountdownCooldown(byte skillNumber)
    {
        int index = skillNumber;
        Debug.Log("Courotine called");
        while (cooldownTimers[index] > 0)
        {
            cooldownTimers[index] -= Time.deltaTime;
            yield return 0;
        }

        canUse[skillNumber] = true;
        yield break;
    }
}

public class BuffInfo
{
    public bool attackStrength;
    public bool attackSpeed;
    public bool defense;
    public bool additionalHealth;
    public bool additionalStamina;
};
