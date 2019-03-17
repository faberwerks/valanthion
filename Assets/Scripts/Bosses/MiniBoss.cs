using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour {

    private GameObject player;

    [SerializeField]
    private GameObject  bombPrep;

    [SerializeField]
    private float  skillCooldownExplode,skillCooldownArea;

    private float  cooldownTimeExplode,cooldownTimeArea;

    [SerializeField]
    private float  bombDamage;

    [SerializeField]
    private float health;

   
    
    // Use this for initialization
    void Start()
    {
        
        player = FindObjectOfType<Player>().gameObject;
        cooldownTimeExplode = skillCooldownExplode;
        cooldownTimeArea = skillCooldownArea;
    }

    // Update is called once per frame
    void Update () {
        skillCooldownExplode -= Time.deltaTime;
        skillCooldownArea -= Time.deltaTime;
        if (skillCooldownExplode <= 0)
        {
            ThrowBomb();
            skillCooldownExplode = cooldownTimeExplode;
        }
        if(skillCooldownArea <= 0 && health <= 50)
        {
            skill();
            skillCooldownArea = cooldownTimeArea;
        }
       
        Death();
    }

    private void ThrowBomb()
    {
        bombPrep.GetComponent<FirePillarPrep>().damage = bombDamage;
        Instantiate(bombPrep, player.transform.position, Quaternion.identity);
    }

    private void Death()
    {
        if(health <= 0)
        {
            GameManager.Instance.Victory();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int atk)
    {
        health -= atk;
    }

    private void skill()
    {
        Instantiate(bombPrep, new Vector3(40-Random.Range(0,30),0), Quaternion.identity);
    }

}
