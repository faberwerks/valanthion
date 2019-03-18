using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SaveLoad.Save(slotIndex);
        Debug.Log("Saved");
    }
}