using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSteps : MonoBehaviour {

    public string tutorialText;

    public int step;
	
    public void ChangeTutorialText(GameObject player, GameObject tutorCanvas)
    {
        player.GetComponent<TutorialTextController>().latestStep = step;
        tutorCanvas.GetComponent<Text>().text = tutorialText;
    }

}
