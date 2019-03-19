using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterSelection : MonoBehaviour {

    public Button[] stageButtons = new Button[6];

    public int selectedStage = 0;

	// Use this for initialization
	private void Start () {
		for (int i = 0; i < Game.current.latestStage; i++)
        {
            stageButtons[i].interactable = true;
        }
	}
	
    // set currently selected stage
	public void SetSelectedStage(int stageIndex)
    {
        selectedStage = stageIndex;
    }

    // load selected stage
    public void LoadSelectedStage()
    {
        SceneManager.LoadScene(selectedStage);
    }
}
