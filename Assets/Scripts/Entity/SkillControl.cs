using System.Collections;
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

        Debug.Log(skill.name);

        if (cooldownTimers[skillNumber] > 0)
        {
            return;
        }
        else
        {
            cooldownTimers[skillNumber] = skill.cooldownTime;
        }

        if (skill.staminaCost > 0 && player.Stamina >= skill.staminaCost)
        {
            player.Stamina -= skill.staminaCost;
            Debug.Log(player.stamina);
        }
        else
        {
            return;
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

        // Dash handling
        if (skill.dashes)
        {
            player.Dash();
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
        StartCoroutine(CCountdownCooldown(skillNumber));
    }

    /////// COROUTINES ///////
    // a coroutine to countdown skill cooldown
    private IEnumerator CCountdownCooldown(byte skillNumber)
    {
        int index = skillNumber;

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
