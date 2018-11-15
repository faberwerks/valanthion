using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponTypes : byte {SWORD,AXE,SPEAR};

    private string itemId = "002";

    private WeaponTypes weaponType;

    private int atk;
    private int range;
    private int atkSpeed;

    void Awake()
    {
        foreach (string[] currString in GameData.ItemList)
        {
            if (string.Equals(itemId,currString[0]))
            {
                Atk = int.Parse(currString[2]);
                range = int.Parse(currString[3]);
                atkSpeed = int.Parse(currString[4]);

                /*
                Debug.Log(currString[0]);
                Debug.Log(currString[1]);
                Debug.Log(Attack);
                Debug.Log(range);
                Debug.Log(attackSpeed);
                */
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
