using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    private GameObject defeatPanel;

	void Awake () {
        defeatPanel = GameObject.Find("Defeat Panel");
	}

    void Start()
    {
        defeatPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		switch (GameManager.Instance.CurrGameState)
        {
            case GameManager.GameState.DEFEAT:
                DefeatMenu();
                break;
        }
	}

    // a method to activate the defeat menu/panel
    public void DefeatMenu()
    {
        defeatPanel.SetActive(true);
    }
}
