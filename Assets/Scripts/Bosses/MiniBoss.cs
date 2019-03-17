using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour {

    private GameObject player;

    [SerializeField]
    private GameObject  bombPrep;

    [SerializeField]
    private float  skillCooldownExplode;

    private float  cooldownTimeExplode;

    [SerializeField]
    private float  bombDamage;

    [SerializeField]
    private float health;
    
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        cooldownTimeExplode = skillCooldownExplode;
    }

    // Update is called once per frame
    void Update () {
        skillCooldownExplode -= Time.deltaTime;
        if (skillCooldownExplode <= 0)
        {
            ThrowBomb();
            skillCooldownExplode += cooldownTimeExplode;
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
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int atk)
    {
        health -= atk;
    }

}
