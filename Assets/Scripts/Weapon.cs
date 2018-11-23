using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponTypes : byte {SWORD,AXE,SPEAR};

    private string itemId = "001";

    private WeaponTypes weaponType;

    private int atk;
    private float range;
    private int atkSpeed;

    private void Start()
    {
        foreach (string[] currString in GameData.ItemList)
        {
            if (string.Equals(itemId, currString[0]))
            {
                Atk = int.Parse(currString[2]);
                range = int.Parse(currString[3]);
                atkSpeed = int.Parse(currString[4]);

                Debug.Log(currString[1]);
                Debug.Log(currString[2]);
                Debug.Log(currString[3]);
                Debug.Log(currString[4]);

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
            Debug.Log(weaponType);
        }
        else if (int.Parse(itemId) == 2)
        {
            weaponType = WeaponTypes.AXE;
            Debug.Log(weaponType);
        }
        else
        {
            weaponType = WeaponTypes.SPEAR;
            Debug.Log(weaponType);
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

    public int Atk
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
}
