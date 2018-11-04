using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState : byte { START, DEFEAT, VICTORY };

    protected GameObject[] enemies;

    Player player;

    protected GameState currState;

    // Use this for initialization
    void Start () {
        CurrState = GameState.START;

        player = GameObject.FindObjectOfType<Player>();
	}

    // Update is called once per frame
    void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length < 1)
        {
            CurrState = GameState.VICTORY;
        }

		switch (CurrState)
        {
            case GameState.DEFEAT:
                Debug.Log("DEFEAT BOI");
                break;
            case GameState.VICTORY:
                Debug.Log("Victory Boy");
                break;
        }
	}

    // a method to give the player exp
    public void GiveExp(int expValue)
    {
        player.Exp = expValue;
    }

    /////// PROPERTIES ///////
    public GameState CurrState
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
}
