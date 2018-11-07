using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;

    private Vector3 currPos;

    private const float OFFSET = -10;
    
    // Update is called once per frame
    void LateUpdate () {
        currPos = player.transform.position;
        currPos.z += OFFSET;

        transform.position = currPos;
	}

}
