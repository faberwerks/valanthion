using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFilling : MonoBehaviour {

	[SerializeField] // show image field on inspector
	private Image content;

	[SerializeField] // show fill amount field on inspector
	private float fill;

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        fill = player.Health * 0.01f;
		fillBar();
	}

    // a method to fill bar
	public void fillBar(){
		content.fillAmount = fill;
	}
}
