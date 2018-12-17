using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Patrol();
    void Guard();
    void Chase();
    void Attack();
    void Retreat();
}

public class Enemy : Entity
{
    public enum EnemyState : byte { PATROL, GUARD, CHASE, ATTACK, RETREAT }

    protected GameObject player;

    protected StageSetting stageSetting;

    protected Vector3 originalPos;

    protected Vector2 currDir;

    protected Weapon weapon;

    public EnemyState initialState;
    protected EnemyState currState;

    protected float atkTimer;
    protected float distance;
    protected float range;
    // the following variables are to countdown the change colour after getting hit
    protected float colorTime;
    protected float colorTimer;

    protected int playerLayer;

    protected ushort expValue;

    protected override void CheckDeath()
    {
        if (Health <= 0)
        {
            stageSetting.RemoveEnemy(expValue, gameObject);
            Destroy(gameObject);
        }
    }

    // a method to handle enemy taking damage
    public override void TakeDamage(float atk)
    {
        base.TakeDamage(atk);
        StartCoroutine(CTimeColorChange());
    }

    // a method to get a reference to the stage setting
    public void SetStageSetting(StageSetting stageSetting)
    {
        this.stageSetting = stageSetting;
    }

    /////// COROUTINES ///////
    protected IEnumerator CTimeColorChange()
    {
        sprRend.color = new Color(255f, 0.0f, 0.0f, 255f);
        colorTimer = colorTime;

        while (colorTimer > 0)
        {
            colorTimer -= Time.deltaTime;
            yield return 0;
        }

        sprRend.color = new Color(255f, 255f, 255f, 255f);
        yield break;
    }

    /////// PROPERTIES ///////
    public EnemyState InitialState
    {
        get
        {
            return initialState;
        }
        set
        {
            this.initialState = value;
        }
    }

    public EnemyState CurrState
    {
        get
        {
            return currState;
        }
        set
        {
            this.currState = value;
        }
    }

    public ushort ExpValue
    {
        get
        {
            return expValue;
        }
        set
        {
            this.expValue = value;
        }
    }

}
