using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeButton : MonoBehaviour {

    private Button buttonComponent;

    public int prevId;
    public int prevId2;

    public bool hasTwoRequirements;

	// Use this for initialization
	private void Start () {
        buttonComponent = GetComponent<Button>();
	}
	
	// Update is called once per frame
	private void Update () {
        if (!hasTwoRequirements)
        {
            if (Game.current.skills[prevId] != 0)
            {
                buttonComponent.interactable = true;
            }
            else
            {
                buttonComponent.interactable = false;
            }
        }
        else
        {
            if (Game.current.skills[prevId] != 0 || Game.current.skills[prevId2] != 0)
            {
                buttonComponent.interactable = true;
            }
            else
            {
                buttonComponent.interactable = false;
            }
        }
	}
}
