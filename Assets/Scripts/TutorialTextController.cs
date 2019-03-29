using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextController : MonoBehaviour {

    [SerializeField]
    public GameObject tutorialCanvas;

    public int latestStep;


    private void Start()
    {
        tutorialCanvas = GameObject.FindGameObjectWithTag("TutorialCanvas");
        latestStep = 1;
        if (Game.current.latestStage > 1)
        {
            tutorialCanvas.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && latestStep == 6)
        {
            tutorialCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggered");
        if(collision.tag == "TutorialToggler")
        {
            var tutorTrigger = collision.gameObject.GetComponent<TutorialSteps>();
            if (latestStep < tutorTrigger.step)
            {
                tutorTrigger.ChangeTutorialText(gameObject, tutorialCanvas);
            }
        }
    }

}
