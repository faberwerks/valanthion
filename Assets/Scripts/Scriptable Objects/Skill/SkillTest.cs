using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTest : MonoBehaviour {

    public int MyProperty { get; set; }

    // Use this for initialization
    void Start () {
        MyProperty = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(MyProperty);
	}
}
