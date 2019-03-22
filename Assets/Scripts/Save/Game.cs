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

    public int slotIndex;
    public int latestStage;
    public int skillPoints;
    public int equippedWeaponID;
   
    public Game()
    {
        saveName = "";

        skills = new int[6];
        skills[0] = 1;
        for (int i = 1; i < 6; i++)
        {
            skills[i] = 0;
        }

        weapons = new int[3];
        weapons[0] = 1;
        for (int i = 1; i < 3; i++)
        {
            weapons[i] = 0;
        }

        latestStage = 1;

        skillPoints = 0;
    }
}
