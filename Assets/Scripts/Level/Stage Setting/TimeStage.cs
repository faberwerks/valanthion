using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStage : StageSetting {

    [SerializeField]
    private Text timeText;

    private Player player;

    public float countdownTime; // in seconds
    private float countdownTimer;

    private bool timeIsUp;
    private bool hasWon;

    private void Start()
    {
        StageSettingStart();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        countdownTimer = countdownTime;

        timeIsUp = false;
        hasWon = false;
    }

    private void Update()
    {
        CountUp();

        if (!player.HasDied && !timeIsUp)
        {
            CountDown();
        }
        else if (timeIsUp && !hasWon)
        {
            GameManager.Instance.Victory();
            hasWon = true;
        }
    }

    // a method to count down
    private void CountDown()
    {
        if (countdownTimer > 0 && CanCount())
        {
            countdownTimer -= Time.deltaTime;
            timeText.text = ((int)countdownTimer / 60).ToString() + " : " + ((int)countdownTimer % 60).ToString();
        }
        else
        {
            timeIsUp = true;
        }
    }
}
