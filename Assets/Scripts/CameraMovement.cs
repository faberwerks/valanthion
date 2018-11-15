using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject player;

    private Vector3 currPos;

    private const float OFFSET = -10;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate () {
        currPos = player.transform.position;
        currPos.z += OFFSET;

        transform.position = currPos;
	}

}
