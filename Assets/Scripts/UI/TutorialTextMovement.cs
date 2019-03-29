using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextMovement : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    public float yOffset;

	// Use this for initialization
	void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = new Vector3(player.transform.position.x, 
                                            player.transform.position.y + yOffset, gameObject.transform.position.z);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        gameObject.transform.position = new Vector3(player.transform.position.x,
                                        player.transform.position.y + yOffset, gameObject.transform.position.z);
    }
}
