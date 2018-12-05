using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private float time = 1.0f;
    private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            GameObject obj = ObjectPooler.current.GetPooledObject();

            obj.transform.position = transform.position;
            obj.GetComponent<ArrowBehavior>().CurrDir = Vector2.left;
            obj.SetActive(true);

            timer = time;
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
}
