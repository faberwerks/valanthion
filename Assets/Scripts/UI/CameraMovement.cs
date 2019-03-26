using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour {

    private GameObject player;

    private Vector3 currPos;

    public float zOffset = -10.0f;
    public float topBorder;
    public float rightBorder;
    public float bottomBorder;
    public float leftBorder;

    private float camHeight;
    private float camWidth;

    private int stageNumber;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        player = GameObject.FindGameObjectWithTag("Player");
        stageNumber = SceneManager.GetActiveScene().buildIndex;
    }

    void LateUpdate ()
    {
        currPos = player.transform.position;
        currPos.z += zOffset;

        if(stageNumber == 1 || stageNumber == 2)
        {
            var clampedX = Mathf.Clamp(player.transform.position.x, leftBorder + camWidth, rightBorder - camWidth);
            var clampedY = Mathf.Clamp(player.transform.position.y , bottomBorder + camHeight, topBorder - camHeight);
            currPos = new Vector3(clampedX, clampedY, currPos.z);
        }
            
        transform.position = currPos;
	}

}
