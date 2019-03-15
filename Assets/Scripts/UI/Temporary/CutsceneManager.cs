using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour {

    public GameObject[] cutscenes = new GameObject[5];

    public float interval = 5f;

	// Use this for initialization
	private void Start () {
        StartCoroutine(CStartCutscenes());
	}
	
	private IEnumerator CStartCutscenes()
    {
        yield return new WaitForSeconds(interval);
        cutscenes[0].SetActive(false);
        cutscenes[1].SetActive(true);
        yield return new WaitForSeconds(interval);
        cutscenes[1].SetActive(false);
        cutscenes[2].SetActive(true);
        yield return new WaitForSeconds(interval);
        cutscenes[2].SetActive(false);
        cutscenes[3].SetActive(true);
        yield return new WaitForSeconds(interval);
        cutscenes[3].SetActive(false);
        cutscenes[4].SetActive(true);
        yield return new WaitForSeconds(interval);
        SceneManager.LoadScene("DemoLevel2");
    }
}
