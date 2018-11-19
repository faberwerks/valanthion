using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<ItemInfo> items = new List<ItemInfo>();

    public const int numItemSlots = 2;

    private void Awake()
    {
        SetUpItems();
    }

    // a method to set up the array
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

public class ItemInfo
{
    public string itemName;
    public int value;
    public int count;
}
