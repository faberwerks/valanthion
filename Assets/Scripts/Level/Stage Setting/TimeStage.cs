﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStage : StageSetting {

    [SerializeField]
    private GameObject time;

    [SerializeField]
    private GameObject canvas;

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
        time = Instantiate(time, canvas.transform);
        timeText = time.GetComponentInChildren<Text>();

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
            Debug.Log("time is up and has not won!");
            hasWon = true;
            GameManager.Instance.Victory();
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
            if (GameManager.Instance.CurrGameState != GameManager.GameState.PAUSED)
            {
                timeIsUp = true;
            }
        }
    }
}
