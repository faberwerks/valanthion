using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;

    private const float OFFSET = -10;
    
    // Update is called once per frame
    void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + OFFSET);
	}

}
