using UnityEngine;

public class Inventory : MonoBehaviour {
    public Item[] items = new Item[numItemSlots];

    public const int numItemSlots = 2;

    // a method to add an item to the inventory
	public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return;
            }
        }
    }

    // a method to remove an item from the inventory
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                return;
            }
        }
    }
}
