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
        Game.current = new Game();
        Game.current.saveName = newSave.saveName.text;
        Game.current.slotIndex = this.slotIndex;
        SaveLoad.Save(slotIndex);
        Debug.Log("Saved");
    }

    public void LoadGame()
    {
        Game.current = SaveLoad.savedGames[slotIndex];
        SceneManager.LoadScene("GameMenu");
    }
}