using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour {

    public GameObject[] saveSlot;

	void Start () {
        saveSlot = new GameObject[3];
        CheckSaveFiles();
    }

    void CheckSaveFiles()
    {
        for (int i = 0; i < 3; i++)
        {
            if(SaveLoad.savedGames[i] != null)
            {
                saveSlot[i].GetComponentInChildren<Text>().text = SaveLoad.savedGames[i].saveName;
            }
        }
    }
}
