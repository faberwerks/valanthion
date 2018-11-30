using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFilling : BarFilling {

	// Use this for initialization
	void Start () {
        // Base class initialisation
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        fill = player.Health * 0.01f;
        FillBar();
    }
}

