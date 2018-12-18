using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsCount : MonoBehaviour {

	public Text countUI;
	public int count = 0;
	public int index = 0;
	public string itemName;

	private Inventory playerInv;

	// Use this for initialization
	void Start () {
		playerInv = GameObject.FindGameObjectWithTag ("Player").GetComponent<Inventory> ();
		countUI = GetComponent<Text> ();

		for (int i = 0; i < playerInv.items.Count; i++) {
			if (playerInv.items[i].itemName == itemName) {
				index = i;
				break;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		count = playerInv.items[index].count;
		countUI.text = count.ToString();
	}
}
