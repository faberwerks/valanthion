using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFilling : MonoBehaviour {

    protected Player player;

    [SerializeField] // show image field on inspector
	protected Image content;

	[SerializeField] // show fill amount field on inspector
	protected float fill;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		FillBar();
	}

    // a method to fill bar
	public void FillBar(){
		content.fillAmount = fill;
	}
}
