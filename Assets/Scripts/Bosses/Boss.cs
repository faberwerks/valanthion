using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity {

    private GameObject player;

    [SerializeField]
    private GameObject spear,bombPrep;
    
    [SerializeField]
    private float skillCooldownSpear, skillCooldownExplode;

    private float cooldownTimeSpear, cooldownTimeExplode;

    [SerializeField]
    private float spearDamage, bombDamage;
    

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>().gameObject;
        cooldownTimeSpear = skillCooldownSpear;
        cooldownTimeExplode = skillCooldownExplode;
	}
	
	// Update is called once per frame
	void Update () {
        skillCooldownSpear -= Time.deltaTime;
        skillCooldownExplode -= Time.deltaTime;
        if(skillCooldownSpear <= 0)
        {
            ThrowSpear();
            skillCooldownSpear += cooldownTimeSpear;
        }
        if (skillCooldownExplode <= 0)
        {
            ThrowBomb();
            skillCooldownExplode += cooldownTimeExplode;
        }
        CheckDeath();
    }

    private void ThrowSpear()
    {
        int rand = Random.Range(1, 4);
        spear.GetComponent<Spear>().damage = spearDamage;

        switch (rand){
            case 1:
                Instantiate(spear, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                break;
            case 2:
                Instantiate(spear, new Vector3(transform.position.x, 6, transform.position.z), Quaternion.identity);
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

    private void KnockBack(float force)
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

}
