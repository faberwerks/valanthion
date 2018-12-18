using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetting : MonoBehaviour
{
    protected List<GameObject> enemies;

    protected float countupTimer;

    protected ushort gainedExp;

    // a method to get a reference to all enemies in the stage
    protected void FindEnemies()
    {
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

        enemies = new List<GameObject>();

        foreach (GameObject enemy in enemiesArray)
        {
            enemy.GetComponent<Enemy>().SetStageSetting(this);
            enemies.Add(enemy);
        }
    }

    // a method to process enemy death
    public void RemoveEnemy(ushort expValue, GameObject enemyObject)
    {
        GainedExp += expValue;
        enemies.Remove(enemyObject);
    }

    // a method to initialise variables and references
    protected void StageSettingStart()
    {
        countupTimer = 0.0f;

        FindEnemies();

        GameManager.Instance.Playing();
    }

    // a method to count up
    protected void CountUp()
    {
        if (CanCount())
        {
            countupTimer += Time.deltaTime;
        }
    }

    // a method to check if can count
    protected bool CanCount()
    {
        if (GameManager.Instance.CurrGameState == GameManager.GameState.PLAYING)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /////// PROPERTIES ///////
    public ushort GainedExp
    {
        get
        {
            return gainedExp;
        }
        set
        {
            this.gainedExp = value;
        }
    }
}
