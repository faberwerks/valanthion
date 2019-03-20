using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBackgroundMusic : MonoBehaviour {

    private AudioSource audioSource;

    private int currentSceneIndex;

	// Use this for initialization
	private void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	private void Update () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if ((currentSceneIndex > 0 && currentSceneIndex < 7) || currentSceneIndex == 9)
        {
            audioSource.Pause();
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.time = 0;
                audioSource.Play();
            }
        }
	}
}
