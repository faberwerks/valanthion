using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<ItemInfo> items = new List<ItemInfo>();

    private void Awake()
    {
        SetUpItems();
    }

    // a method to set up the inventory array
    private void SetUpItems()
    {
        ItemInfo healthPotionInfo = new ItemInfo();
        healthPotionInfo.itemName = "Health Potion";
        healthPotionInfo.value = 10;
        healthPotionInfo.count = 0;

        items.Add(healthPotionInfo);

        ItemInfo staminaPotionInfo = new ItemInfo();
        staminaPotionInfo.itemName = "Stamina Potion";
        staminaPotionInfo.value = 20;
        staminaPotionInfo.count = 0;

        items.Add(staminaPotionInfo);
		//Debug.Log ("STAMINA PLUS");

        ItemInfo attackPotionInfo = new ItemInfo();
        attackPotionInfo.itemName = "Attack Potion";
        attackPotionInfo.value = 10;
        attackPotionInfo.count = 0;

        items.Add(attackPotionInfo);

        ItemInfo defensePotionInfo = new ItemInfo();
        defensePotionInfo.itemName = "Defense Potion";
        defensePotionInfo.value = 10;
        defensePotionInfo.count = 0;

        items.Add(defensePotionInfo);
    }

    // a method to add an item to the inventory
	public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemToAdd.itemName)
            {
                items[i].count++;
                break;
            }
        }
    }

    // a method to remove an item from the inventory
    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemName)
            {
                items[i].count--;
                break;
            }
        }
    }
}

/*
 * A class to hold item information
 */
public class ItemInfo
{
    public string itemName;
    public int value;
    public int count;
}