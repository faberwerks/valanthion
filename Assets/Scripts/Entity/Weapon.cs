using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponTypes : byte {SWORD,AXE,SPEAR};

    public string itemId = "001";

    private WeaponTypes weaponType;

    private float atk;
    private float range;
    private float atkSpeed;

    private void Start()
    {
        foreach (string[] currString in GameData.ItemList)
        {
            if (string.Equals(itemId, currString[0]))
            {
                Atk = float.Parse(currString[2]);
                Range = int.Parse(currString[3]);
                AtkSpeed = float.Parse(currString[4]);
                break;
            }
        }

        SetWeaponType();
    }

    // a method to set the weapon type
    protected void SetWeaponType()
    {
        if (int.Parse(itemId) == 1)
        {
            weaponType = WeaponTypes.SWORD;
        }
        else if (int.Parse(itemId) == 2)
        {
            weaponType = WeaponTypes.AXE;
        }
        else
        {
            weaponType = WeaponTypes.SPEAR;
        }
    }

    /////// PROPERTIES ///////
    public WeaponTypes WeaponType
    {
        get
        {
            return weaponType;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }
        set
        {
            this.range = value;
        }
    }

    public float Atk
    {
        get
        {
            return atk;
        }
        set
        {
            this.atk = value;
        }
    }

    public float AtkSpeed
    {
        get
        {
            return atkSpeed;
        }
        set
        {
            this.atkSpeed = value;
        }
    }

}
