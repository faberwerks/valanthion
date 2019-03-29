using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Entity {

    private GameObject player;

    [SerializeField]
    private GameObject  bombPrep;

    public float changeStatePercentage;

    [SerializeField]
    private float  skillCooldownExplode,skillCooldownArea;

    private float  cooldownTimeExplode,cooldownTimeArea;

    [SerializeField]
    private float  bombDamage;
    
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();
        
        initialColor = sprRend.color;

        colorTime = 0.5f;

        initialMaxHealth = health;
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
            anim.SetTrigger("Attacking");
            ThrowBomb();
            skillCooldownExplode = cooldownTimeExplode;
        }
        if(skillCooldownArea <= 0 && health <= (changeStatePercentage/100 * initialMaxHealth))
        {
            anim.SetTrigger("Attacking");
            Skill();
            skillCooldownArea = cooldownTimeArea;
        }
       
        CheckDeath();
    }

    private void ThrowBomb()
    {
        bombPrep.GetComponent<FirePillarPrep>().damage = bombDamage;
        Instantiate(bombPrep, player.transform.position, Quaternion.identity);
    }

    protected override void CheckDeath()
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
        audioSource.Play();
        StartCoroutine(CTimeColorChange());
    }

    private void Skill()
    {
        Instantiate(bombPrep, new Vector3(40-Random.Range(0,30),0), Quaternion.identity);
    }

   
}
