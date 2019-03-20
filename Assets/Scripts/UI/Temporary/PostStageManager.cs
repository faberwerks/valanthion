using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostStageManager : MonoBehaviour {

    [SerializeField]
    private Text stageName,stageNumber;
    [SerializeField]
    private Text timeText;

	// Use this for initialization
	void Start () {
        float time = PlayerPrefs.GetFloat("Time", 0);
        stageName.text = PlayerPrefs.GetString("StageName");
        stageNumber.text = "Stage " + (PlayerPrefs.GetInt("CurrentStage", 0)).ToString();
        timeText.text = ((int)time/60).ToString() +" : "+ ((int)time %60).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // a method to move scenes
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentStage", 0) + 1);
    }
}
