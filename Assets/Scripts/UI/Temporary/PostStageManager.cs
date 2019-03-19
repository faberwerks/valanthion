using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostStageManager : MonoBehaviour {

    [SerializeField]
    private Text stageName;

	// Use this for initialization
	void Start () {
        stageName.text = PlayerPrefs.GetString("StageName");
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
