using UnityEngine;

public class Item : MonoBehaviour, IPickupable<GameObject> {
    public string itemName;

    // a method called when picked up
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
