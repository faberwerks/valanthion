using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item, IPickupable<GameObject> {

    void Awake()
    {
        name = "Health Potion";
    }

    public void OnPickup(GameObject player)
    {
        player.GetComponent<Inventory>().AddItem(GetComponent<Item>());
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPickup(collision.gameObject);
        }
    }
}
