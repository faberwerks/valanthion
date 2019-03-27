using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveSlot : MonoBehaviour {

    public GameObject[] saveSlot = new GameObject[3];

    // private SaveLoadInput sli;

	void Start () {
        // sli = GetComponent<SaveLoadInput>();
        CheckSaveFiles();
        if(SceneManager.GetActiveScene().name == "LoadGame")
        {
            CheckLoadGame();
        }
    }

    public void CheckSaveFiles()
    {
        for (int i = 0; i < 3; i++)
        {
            if (SaveLoad.savedGames[i] != null)
            {
                //Debug.Log("save file " + i +" loaded");
                saveSlot[i].GetComponentInChildren<Text>().text = "\t" + SaveLoad.savedGames[i].saveName;
            }
        }
    }

    public void CheckLoadGame()
    {
        for (int i = 0; i < 3; i++)
        {
            if (SaveLoad.savedGames[i] == null)
            {
                saveSlot[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}
