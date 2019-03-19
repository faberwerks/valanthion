using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableSkillPoints : MonoBehaviour {

    private Text textComponent;

	// Use this for initialization
	private void Start () {
        textComponent = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        textComponent.text = Game.current.skillPoints.ToString();
	}
}
