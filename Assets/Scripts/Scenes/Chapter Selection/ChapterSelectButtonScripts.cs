using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelectButtonScripts : MonoBehaviour {

	public void ToggleGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void ToggleChapter(int level)
    {
        //Will load the selected Chapter using the function:
        //SceneManager.LoadScene("Chapter" + level); 
        //(not tested whether it works or not)
    }
}
