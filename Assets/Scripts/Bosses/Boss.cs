using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity {

    private GameObject player;

    [SerializeField]
    private GameObject spear,bombPrep;
    
    [SerializeField]
    private float skillCooldownSpear, skillCooldownExplode, patternCooldown;

    private float cooldownTimeSpear, cooldownTimeExplode, patternTime;

    [SerializeField]
    private float spearDamage, bombDamage;
    
    [SerializeField]
    private int[] pattern;
    private int index,patternRandomize;
    

    // Use this for initialization
    void Start () {
        index = 0;
        patternRandomize = 0;
        player = FindObjectOfType<Player>().gameObject;
        patternTime = patternCooldown; 
        cooldownTimeSpear = skillCooldownSpear;
        cooldownTimeExplode = skillCooldownExplode;
	}
	
	// Update is called once per frame
	void Update () {
        skillCooldownSpear -= Time.deltaTime;
        skillCooldownExplode -= Time.deltaTime;
        patternCooldown -= Time.deltaTime;
        if(skillCooldownSpear <= 0)
        {
            ThrowSpear();
            skillCooldownSpear = cooldownTimeSpear;
        }
        if (skillCooldownExplode <= 0)
        {
            ThrowBomb();
            skillCooldownExplode = cooldownTimeExplode;
        }
        if(patternCooldown <= 0)
        {
            if(index >= 9)
            {
                index = 0;
                patternRandomize = Random.Range(0, 3);
            }
            Pattern1();
            index++;
            patternCooldown = patternTime;
        }
        CheckDeath();
    }

    private void ThrowSpear()
    {
        int rand = Random.Range(1, 4);
        spear.GetComponent<Spear>().damage = spearDamage;

        switch (rand){
            case 1:
                Instantiate(spear, new Vector3(transform.position.x, -2, transform.position.z), Quaternion.identity);
                break;
            case 2:
                Instantiate(spear, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                break;
            case 3:
                Instantiate(spear, new Vector3(transform.position.x, -6, transform.position.z), Quaternion.identity);
                break;
        }
    }

    private void ThrowBomb()
    {
        bombPrep.GetComponent<FirePillarPrep>().damage = bombDamage;
        Instantiate(bombPrep,player.transform.position,Quaternion.identity);
    }

    public void KnockBack(float force)
    {

    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            GameManager.Instance.Victory();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int atk)
    {
        health -= atk;
    }

    private void Pattern1()
    {
        pattern[index] = (pattern[index] + patternRandomize) % 3;
        spear.GetComponent<Spear>().damage = spearDamage;

        switch (pattern[index]+1)
        {
            case 1:
                Instantiate(spear, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                break;
            case 2:
                Instantiate(spear, new Vector3(transform.position.x, -2, transform.position.z), Quaternion.identity);
                break;
            case 3:
                Instantiate(spear, new Vector3(transform.position.x, -6, transform.position.z), Quaternion.identity);
                break;
        }

    }
}
