using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerStage3 : MonoBehaviour {

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float timer;
	
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerText.text = ((int)timer/60).ToString() + " : " + ((int)timer % 60).ToString();
		if(timer <= 0)
        {
            FindObjectOfType<Player>().Health = 0;
        }
	}
}
