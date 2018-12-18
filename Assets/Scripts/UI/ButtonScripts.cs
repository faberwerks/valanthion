using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    // a method to continue/unpause the game
    public void Continue()
    {
        GameManager.Instance.Pause(false);
        Time.timeScale = 1.0f;
    }

    // a method to handle application exit
    public void Exit()
    {
        Application.Quit();
    }

    // a method to go to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // a method to start playing
    public void Play()
    {
        SceneManager.LoadScene("DemoLevel");
    }

    // a method to restart a level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // a method to handle trying again
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
