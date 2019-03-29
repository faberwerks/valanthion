using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinimapController : MonoBehaviour {

    private Vector3 currPos;

    public float topBorder;
    public float rightBorder;
    public float bottomBorder;
    public float leftBorder;

    private float camHeight;
    private float camWidth;

    private int stageNumber;

    private void Awake()
    {
        camHeight = GetComponent<Camera>().orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        stageNumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void LateUpdate () {
        if (stageNumber == 1 || stageNumber == 2)
        {
            currPos = transform.position;
            var clampedX = Mathf.Clamp(transform.position.x, leftBorder + camWidth, rightBorder - camWidth);
            var clampedY = Mathf.Clamp(transform.position.y, bottomBorder + camHeight, topBorder - camHeight);
            currPos = new Vector3(clampedX, clampedY, currPos.z);
            transform.position = currPos;
        }
    }
}
