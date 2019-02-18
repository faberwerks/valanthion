using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagesManager : MonoBehaviour {

    public Button[] stageButtons;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Game.current.currentStage; i++)
        {
            stageButtons[i].interactable = true;
        }
    }
}
