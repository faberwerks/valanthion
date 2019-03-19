using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSkillButton : MonoBehaviour {

    private Button buttonComponent;

    public int skillId;

	// Use this for initialization
	private void Start () {
        buttonComponent = GetComponent<Button>();
	}
	
	// Update is called once per frame
	private void Update () {
		if (Game.current.skillPoints <= 0 || Game.current.skills[skillId] != 0)
        {
            buttonComponent.interactable = false;
        }
        else
        {
            buttonComponent.interactable = true;
        }
	}
}
