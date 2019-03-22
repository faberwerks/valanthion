using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostStageManager : MonoBehaviour {

    public GameObject reward;

    [SerializeField]
    private Text stageName,stageNumber;
    [SerializeField]
    private Text timeText,skillPointText;


	// Use this for initialization
	void Start () {
        float time = PlayerPrefs.GetFloat("Time", 0);
        stageName.text = PlayerPrefs.GetString("StageName");
        stageNumber.text = "Stage " + (PlayerPrefs.GetInt("CurrentStage", 0)).ToString();
        timeText.text = ((int)time/60).ToString() +" : "+ ((int)time %60).ToString();

        //need to add skill points at specific stages

        CheckSkillPoint();
        CheckReward();
	}

    private void CheckReward()
    {
        int currStage = PlayerPrefs.GetInt("CurrentStage", 0);
        Debug.Log(PlayerPrefs.GetInt("CurrentStage", 0));
        if (currStage == 2 || currStage == 4) {
            Debug.Log(PlayerPrefs.GetInt("CurrentStage", 0));
            reward.SetActive(true);
            reward.GetComponent<RewardManager>().SetReward(currStage);
        }
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

    private void CheckSkillPoint()
    {
        int stage = PlayerPrefs.GetInt("CurrentStage", 0);
        if (stage < 4 && Game.current.skillPoints < stage)
        {
            Game.current.skillPoints++;
            skillPointText.text = "1";
        }
        else
        {
            skillPointText.text = "0";
        }
    }
}
