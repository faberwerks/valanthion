using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    // private int currExp;
    public int stageID;
    public int skillPointReward;
    public int perkPointReward;

    private void Awake()
    {
        // currExp = Game.current.exp;
        if (Game.current.currentStage < stageID)
        {
            Game.current.currentStage = stageID;
        }
    }

    // a method to handle post-level processing after winning
    public void WinLevel()
    {
        Game.current.skillPoints += skillPointReward;
        Game.current.perkPoints += perkPointReward;
    }
}
