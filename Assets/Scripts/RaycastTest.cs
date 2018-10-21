using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour {

    public LayerMask mask = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 10.0f, LayerMask.GetMask("Player"));

        if (hit != null)
        {
            Debug.Log(hit.distance);
        }
	}
}
