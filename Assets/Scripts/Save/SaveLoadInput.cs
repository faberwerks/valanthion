using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadInput : MonoBehaviour {

    public int slotIndex;

    public void SetSlotIndex(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }

    public void SaveNewGame(NewGameButtonScript newSave)
    {
        Game.current = new Game
        {
            saveName = newSave.saveName.text,
            slotIndex = this.slotIndex
        };
        SaveLoad.Save(slotIndex);
        InputManager.instance.SetKeysFromSaveFile(Game.current.skillKeys);
        Debug.Log("Saved");
    }

    public void LoadGame()
    {
        Game.current = SaveLoad.savedGames[slotIndex];
        InputManager.instance.SetKeysFromSaveFile(Game.current.skillKeys);
        SceneManager.LoadScene("GameMenu");
    }
}