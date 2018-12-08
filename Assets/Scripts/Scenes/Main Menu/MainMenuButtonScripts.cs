using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScripts : MonoBehaviour {

    private MainMenuManager mainMenuManager;

    private void Awake()
    {
        mainMenuManager = GetComponent<MainMenuManager>();
    }

    // a method to toggle the new game panel
    public void ToggleNewGame()
    {
        // mainMenuManager.TogglePanel(mainMenuManager.newGamePanel);
        SceneManager.LoadScene("DemoLevel");
    }

    // a method to toggle the load game panel
    public void ToggleLoadGame()
    {
        mainMenuManager.TogglePanel(mainMenuManager.loadGamePanel);
    }

    // a method to toggle the credits panel
    public void ToggleCredits()
    {
        mainMenuManager.TogglePanel(mainMenuManager.creditsPanel);
    }

    // a method to toggle the exit =panel
    public void ToggleExit()
    {
        mainMenuManager.TogglePanel(mainMenuManager.exitPanel);
    }
}
