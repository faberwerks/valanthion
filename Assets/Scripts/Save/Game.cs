using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{

    public static Game current;

    public string saveName;

    public int[] skills;
    public int[] perks;

    public int currentStage;
    public int skillPoints;
    public int perkPoints;
    public int equippedWeaponID;
    public int equippedArmourID;
    // public int exp;
    // public int level;

    public Game()
    {
        saveName = "";

        skills = new int[18];
        perks = new int[5];

        currentStage = 1;
        skillPoints = 0;
        perkPoints = 0;
        // exp = 0;
        // level = 1;
    }
}
