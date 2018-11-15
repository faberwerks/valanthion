using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    public enum GameState : byte { PLAYING, VICTORY, DEFEAT, PAUSED };

    private static GameManager instance;

    protected GameState currGameState;

    // REMINDER: Move all this to LEVEL MANAGER script
    /*
    protected GameObject[] enemies;

    Player player;

    void Start () {
        CurrGameState = GameState.PLAYING;

        player = GameObject.FindObjectOfType<Player>();
	}

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
    */

    // a method to handle victory
    public void Victory(bool hasWon)
    {
        if (hasWon)
        {
            CurrGameState = GameState.VICTORY;
            Time.timeScale = 0.0f;
        }
        else
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    // a method to handle defeat
    public void Defeat(bool defeated)
    {
        if (defeated)
        {

            CurrGameState = GameState.DEFEAT;
            Time.timeScale = 0.0f;
        }
        else
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    // a method to handle pausing
    public void Pause(bool paused)
    {
        if (paused)
        {
            CurrGameState = GameState.PAUSED;
            Time.timeScale = 0.0f;
        }
        else
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    // a method to reset game state
    public void Playing(bool playing)
    {
        if (playing)
        {
            CurrGameState = GameState.PLAYING;
            Time.timeScale = 1.0f;
        }
    }

    // REMINDER: Where is this supposed to go?
    // a method to give the player exp
    /*
    public void GiveExp(int expValue)
    {
        player.Exp = expValue;
    }
    */

    /////// PROPERTIES ///////
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    
    public GameState CurrGameState
    {
        get
        {
            return currGameState;
        }
        set
        {
            this.currGameState = value;
        }
    }
}
