using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor : MonoBehaviour {

    public Transform objectToFollow;

    public Vector3 localOffset;

    // RectTransform myCanvas;

	// Use this for initialization
	void Start () {
        // myCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
	}

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 worldPoint = objectToFollow.TransformPoint(localOffset);

        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(worldPoint);

        transform.localPosition = viewportPoint;
    }
}
