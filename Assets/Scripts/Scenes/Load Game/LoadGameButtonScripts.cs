using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGameButtonScripts : MonoBehaviour{
    public void ToggleMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToggleGameMenu()
    {
        //needs to take file from save file

        //SceneManager.LoadScene("GameMenu");
    }
}
