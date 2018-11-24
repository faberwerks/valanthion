using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject player;

    private Vector3 currPos;

    public float offset = -10.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate ()
    {
        currPos = player.transform.position;
        currPos.z += offset;

        transform.position = currPos;
	}

}
