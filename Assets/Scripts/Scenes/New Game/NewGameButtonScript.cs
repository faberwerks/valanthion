using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameButtonScript : MonoBehaviour{

    public Text saveName;
    public GameObject saveSlotPanel;
    public GameObject invalidTextObject;

    public void ToggleMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TogglePrologue()
    {
        SceneManager.LoadScene("Prologue");
    }

    //verify that the new file name is not empty and have less than 20 characters
    public void VerifyName()
    {
        if (saveName.text.Length > 0 && saveName.text.Length < 20)
        {
            saveSlotPanel.SetActive(true);
            invalidTextObject.SetActive(false);
        }
        else
        {
            invalidTextObject.SetActive(true);
            //Debug.Log("Invalid");
        }
    }

}
