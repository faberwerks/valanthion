using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponTypes : byte {SWORD,AXE,SPEAR};

    private string itemId = "002";

    private WeaponTypes weaponType;

    private int attack;
    private int range;
    private int attackSpeed;

    void Awake()
    {
        foreach (string[] currString in GameData.itemList)
        {
            
            if(string.Equals(itemId,currString[0]))
            {
                Attack = int.Parse(currString[2]);
                range = int.Parse(currString[3]);
                attackSpeed = int.Parse(currString[4]);

                Debug.Log(currString[0]);
                Debug.Log(currString[1]);
                Debug.Log(Attack);
                Debug.Log(range);
                Debug.Log(attackSpeed);

                Debug.Log("Does this fucking work");
                break;
            }
        }

        SetWeaponType();
    }

    private void Update()
    {
        Debug.Log("FROM WEAPON: " + Attack);
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

    public int Attack
    {
        get
        {
            return attack;
        }
        set
        {
            this.attack = value;
        }
    }
}
