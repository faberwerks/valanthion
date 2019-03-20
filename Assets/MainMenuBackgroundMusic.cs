using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBackgroundMusic : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip mainMenuBGM;
    public AudioClip cutsceneBGM;
    public AudioClip normalStageBGM;
    public AudioClip timerStageBGM;
    public AudioClip bossStageBGM;

    private int currentSceneIndex;

	// Use this for initialization
	private void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	private void Update () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentSceneIndex)
        {
            case 1:
            case 4:
                audioSource.clip = normalStageBGM;
                break;
            case 2:
            case 3:
                audioSource.clip = timerStageBGM;
                break;
            case 5:
            case 6:
                audioSource.clip = bossStageBGM;
                break;
            case 9:
                audioSource.clip = cutsceneBGM;
                break;
            default:
                if (audioSource.clip != mainMenuBGM)
                {
                    audioSource.clip = mainMenuBGM;
                }
                break;
        }
	}
}
