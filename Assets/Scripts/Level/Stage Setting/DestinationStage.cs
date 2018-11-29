using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationStage : StageSetting {

	// Use this for initialization
	private void Start () {
        StageSettingStart();
	}

    private void Update()
    {
        CountUp();
    }

}
