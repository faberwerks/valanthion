using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {

    public enum GameState : byte { PLAYING, VICTORY, DEFEAT, PAUSED };

    private static GameManager instance;

    protected GameState currGameState;

    // a method to handle victory
    public void Victory()
    {
        CurrGameState = GameState.VICTORY;
        Time.timeScale = 0.0f;
        NextScene();
    }

    // a method to handle defeat
    public void Defeat()
    {
        CurrGameState = GameState.DEFEAT;
        Time.timeScale = 0.0f;
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
    public void Playing()
    {
        CurrGameState = GameState.PLAYING;
        Time.timeScale = 1.0f;
    }

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

    private void NextScene()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) != 9)
        {
            PlayerPrefs.SetString("stageName", GameObject.FindObjectOfType<StageSetting>().stageName);
            PlayerPrefs.SetFloat("Time",GameObject.FindObjectOfType<StageSetting>().GameTime());
            Game.current.latestStage = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("11");
        }
    }
}
