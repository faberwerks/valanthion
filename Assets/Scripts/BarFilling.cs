using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFilling : MonoBehaviour {

	[SerializeField] //showing image on inspector
	private Image Content;



	[SerializeField] //showing fillAmount on inspector
	private float Fill;

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        Fill = player.GetHealth() * 0.01f;
		fillBar();

	}

	void fillBar(){
		Content.fillAmount = Fill;
	}
}
