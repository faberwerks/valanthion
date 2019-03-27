using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerStage3 : MonoBehaviour {

    [SerializeField]
    private GameObject canvas, time;

    private Text timeText;
    [SerializeField]
    private float timer;

    private void Start()
    {
        time = Instantiate(time, canvas.transform);
        timeText = time.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        timeText.text = ((int)timer/60).ToString() + " : " + ((int)timer % 60).ToString();
		if(timer <= 0)
        {
            FindObjectOfType<Player>().Health = 0;
        }
	}
}
