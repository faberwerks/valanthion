using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyController : MonoBehaviour {

    [SerializeField]
    private GameObject wave;
	
	// Update is called once per frame
	void Update () {
        // activates next wave if all enemies of the current wave are dead
		if(wave.transform.childCount <= 0 && wave.GetComponent<Wave>().nextWave != null)
        {
            wave.SetActive(false);
            wave = wave.GetComponent<Wave>().nextWave;
            wave.SetActive(true);
        }
        // deactivates final wave
        else if (wave.transform.childCount <= 0 && wave.GetComponent<Wave>().nextWave == null)
        {
            wave.SetActive(false);
        }
	}
}
