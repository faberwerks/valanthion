using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour {

    public GameObject[] saveSlot = new GameObject[3];

	void Start () {
        CheckSaveFiles();
    }

    public void CheckSaveFiles()
    {
        for (int i = 0; i < 3; i++)
        {
            if (SaveLoad.savedGames[i] != null)
            {
                Debug.Log("save file " + i +" loaded");
                saveSlot[i].GetComponentInChildren<Text>().text = "\t" + SaveLoad.savedGames[i].saveName;
            }
        }
    }
}
