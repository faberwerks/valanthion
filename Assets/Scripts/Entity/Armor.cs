using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {

    public ArmorItemList armorItemList;

    public ushort itemId;

    public int Defense { get; set; }

    private void Awake()
    {
        foreach (ArmorItem armor in armorItemList.armorItemList)
        {
            if(armor.itemId == itemId)
            {
                Debug.Log(armor.defense);
                Defense = armor.defense;
                Debug.Log(Defense);
                break;
            }
        }
    }
}
