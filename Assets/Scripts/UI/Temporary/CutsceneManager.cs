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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            SceneManager.LoadScene("DemoLevel2");
        }
    }

    private IEnumerator CStartCutscenes()
    {
        StartCoroutine(FadeIn(0));
        yield return new WaitForSeconds(intervals[0]);
        StartCoroutine(FadeOut(0));

        yield return new WaitForSeconds(intervals[1]);
        StartCoroutine(FadeOut(1));

        yield return new WaitForSeconds(intervals[2]);
        StartCoroutine(FadeOut(2));

        yield return new WaitForSeconds(intervals[3]);
        StartCoroutine(FadeOut(3));

        yield return new WaitForSeconds(intervals[4]);
        StartCoroutine(FadeOut(4));
        SceneManager.LoadScene("DemoLevel2");
    }

    // a method to fade in image
    private IEnumerator FadeIn(int imageIndex)
    {
        SpriteRenderer _sprRend = cutscenes[imageIndex].GetComponent<SpriteRenderer>();

        for (float i = 0; i <= 1; i += Time.deltaTime / 2)
        {
            _sprRend.color = new Color(i, i, i, 1);
            yield return null;
        }
    }

    // a method to fade out image
    private IEnumerator FadeOut(int imageIndex)
    {
        SpriteRenderer _sprRend = cutscenes[imageIndex].GetComponent<SpriteRenderer>();

        for (float i = 1; i >= 0; i -= Time.deltaTime / 2)
        {
            _sprRend.color = new Color(i, i, i, 1);
            yield return null;
        }

        if (imageIndex < 4)
        {
            cutscenes[imageIndex].SetActive(false);
            cutscenes[imageIndex + 1].SetActive(true);
            StartCoroutine(FadeIn(imageIndex + 1));
        }
    }
}
