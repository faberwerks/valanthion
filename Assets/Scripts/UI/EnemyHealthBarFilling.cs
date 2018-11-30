using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarFilling : BarFilling
{
    private Enemy enemy;

    // Use this for initialization
    void Start()
    {
        // Base class initialisation
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        fill = enemy.Health * 0.01f;
        FillBar();
    }
}
