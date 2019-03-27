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
        int _tempLatestStage = Game.current.latestStage;
        if (_tempLatestStage > 6)
        {
            _tempLatestStage = 6;
        }
        for (int i = 0; i < _tempLatestStage; i++)
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
