﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public DemoLevelManager demoLevelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            demoLevelManager.HasKey = true;
            Destroy(gameObject);
        }
    }
}
