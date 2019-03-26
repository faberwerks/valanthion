using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstraint : MonoBehaviour{

    private Vector3 camPos;

    public float topBorder;
    public float rightBorder;
    public float bottomBorder;
    public float leftBorder;

    private float camHeight;
    private float camWidth;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }


    public Vector3 Constraint(Vector3 currPos)
    {
        if (currPos.y + camHeight > topBorder)
        {
            currPos.y = topBorder - camHeight;
        }
        if (currPos.y - camHeight < bottomBorder)
        {
            currPos.y = bottomBorder + camHeight;
        }
        if (currPos.x + camWidth > rightBorder)
        {
            currPos.x = rightBorder - camWidth;
        }
        if (currPos.x - camWidth < leftBorder)
        {
            currPos.x = leftBorder + camWidth;
        }
        return (currPos);
    }   
}