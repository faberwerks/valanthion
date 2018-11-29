using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerSave : ScriptableObject
{
    public string playerName;
    public int[] skillLevels = new int[18];
    public List<int> unlockedArmor;
    public List<int> unlockedWeapons;
    public bool[] unlockedStages = new bool[9];
    public int experience;
    public int skillPoints;
    public int perkPoints;
}
