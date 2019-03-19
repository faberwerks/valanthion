using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour {

    public GameObject[] cutscenes = new GameObject[5];

    public float[] intervals = new float[5];

	// Use this for initialization
	private void Start () {
        StartCoroutine(CStartCutscenes());
	}
	
	private IEnumerator CStartCutscenes()
    {
        yield return new WaitForSeconds(intervals[0]);
        cutscenes[0].SetActive(false);
        cutscenes[1].SetActive(true);
        yield return new WaitForSeconds(intervals[1]);
        cutscenes[1].SetActive(false);
        cutscenes[2].SetActive(true);
        yield return new WaitForSeconds(intervals[2]);
        cutscenes[2].SetActive(false);
        cutscenes[3].SetActive(true);
        yield return new WaitForSeconds(intervals[3]);
        cutscenes[3].SetActive(false);
        cutscenes[4].SetActive(true);
        yield return new WaitForSeconds(intervals[4]);
        SceneManager.LoadScene("DemoLevel2");
    }
}
