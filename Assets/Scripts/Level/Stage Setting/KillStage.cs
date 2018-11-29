using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillStage : StageSetting { 
    
    private void Start()
    {
        StageSettingStart();
    }

    private void Update()
    {
        CountUp();

        if (enemies.Count == 0)
        {
            GameManager.Instance.Victory(true);
        }
    }

}
