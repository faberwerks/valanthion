using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
    
    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
    

}
