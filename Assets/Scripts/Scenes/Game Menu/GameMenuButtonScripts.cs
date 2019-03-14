using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuButtonScripts : MonoBehaviour {

	public void ToggleMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleContinue()
    {
        //Need to get latest level from Save File
        //SceneManager.LoadScene("");
    }

    public void ToggleChapterSelection()
    {
        SceneManager.LoadScene("ChapterSelection");
    }

    public void ToggleCharacterSetting()
    {
        //SceneManager.LoadScene("");
    }

    public void ToggleOptions()
    {
        //SceneManager.LoadScene("");
    }


}
