using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuButtonScripts : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 1;
    }

    // a method to continue the game from the last stage
    public void Continue()
    {
        SceneManager.LoadScene(Game.current.latestStage);
    }

    // a method to load a scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // save current game data
    public void SaveCurrentGame()
    {
        SaveLoad.Save(Game.current.slotIndex);
        Debug.Log("SAVED");
    }
}
