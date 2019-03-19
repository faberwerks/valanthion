using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public static Game current;

    public string saveName;

    public int[] skills;
    public int[] weapons;

    public int latestStage;
    public int skillPoints;
    public int equippedWeaponID;
   
    public Game()
    {
        saveName = "";

        skills = new int[6];
        skills[0] = 1;

        weapons = new int[3];
        weapons[0] = 1;

        latestStage = 1;

        skillPoints = 0;
    }
}
