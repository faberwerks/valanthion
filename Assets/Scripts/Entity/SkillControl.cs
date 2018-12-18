using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour {

    private Player player;

    private SkillProcessor skillProcessor;

    private Vector2 currDir;

    public LayerMask targetLayer;

    private float[] cooldownTimers = new float[6];

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();

        skillProcessor = GetComponent<SkillProcessor>();
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

        Debug.Log(skill.skillName);
        if (cooldownTimers[skillNumber - 1] > 0)
        {
            return;
        }
        else
        {
            cooldownTimers[skillNumber - 1] = skill.cooldownTime;
        }

        if (skill.staminaCost > 0 && player.Stamina >= skill.staminaCost)
        {
            player.Stamina -= skill.staminaCost;
        }
        else
        {
            return;
        }

        // Damage Handling
        if (skill.dealsDamage)
        {
            if (skill.singleTarget)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);

                if (hit)
                {
                    hit.collider.SendMessage("TakeDamage", skill.damage);
                    
                    if (skill.bleeding)
                    {
                        hit.collider.SendMessage("Bleed");
                    }
                }
            }
            else if (skill.multipleTargets)
            {
                Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, new Vector2(5, 1), 0, targetLayer);

                foreach (Collider2D target in targets)
                {
                    target.SendMessage("TakeDamage", skill.damage);
                    
                    if (skill.bleeding)
                    {
                        target.SendMessage("Bleed");
                    }
                }
            }
        }

        // Defense Handling
        if (skill.reducesDefense)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("ReduceDefense", 5);
            }
        }

        // Dash handling
        if (skill.dashes)
        {
            player.Dash();
        }

        // Slowdown, stun, knockback, cripple
        if (skill.slowsDownTarget)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("SlowDown", 1);
            }
        }
        if (skill.stuns)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("Stun");
            }
        }
        if (skill.knocksBack)
        {
            float knockbackForce = 100.0f;

            knockbackForce = player.IsFacingRight ? knockbackForce : knockbackForce * -1;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);

            if (hit)
            {
                hit.collider.SendMessage("KnockBack", knockbackForce);
            }
        }
        if (skill.cripples)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 10.0f, targetLayer);

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

        StartCoroutine(CCountdownCooldown(skillNumber));
    }

    /////// COROUTINES ///////
    // a coroutine to countdown skill cooldown
    private IEnumerator CCountdownCooldown(byte skillNumber)
    {
        int index = skillNumber - 1;

        while (cooldownTimers[index] > 0)
        {
            cooldownTimers[index] -= Time.deltaTime;
            yield return 0;
        }

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
