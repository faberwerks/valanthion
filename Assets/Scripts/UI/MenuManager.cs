﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject defeatPanel;
    public GameObject victoryPanel;
    public GameObject pausePanel;

    void Start()
    {
        defeatPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        CheckPause();

		switch (GameManager.Instance.CurrGameState)
        {
            case GameManager.GameState.PLAYING:
                break;
            case GameManager.GameState.VICTORY:
                VictoryMenu();
                break;
            case GameManager.GameState.DEFEAT:
                DefeatMenu();
                break;
            case GameManager.GameState.PAUSED:
                PauseMenu();
                break;
        }
	}

    // a method to handle pause button input
    public void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Pause(true);
        }
        else if (GameManager.Instance.CurrGameState != GameManager.GameState.PAUSED)
        {
            pausePanel.SetActive(false);
        }
    }

    // a method to activate the defeat menu/panel
    public void DefeatMenu()
    {
        defeatPanel.SetActive(true);
    }

    // a method to activate the victory menu/panel
    public void VictoryMenu()
    {
        victoryPanel.SetActive(true);
    }

    // a method to activate the pause menu/panel
    public void PauseMenu()
    {
        pausePanel.SetActive(true);
    }
}