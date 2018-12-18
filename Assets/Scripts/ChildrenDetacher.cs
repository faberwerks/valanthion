using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenDetacher : MonoBehaviour {

    private void Awake()
    {
        GetComponent<Transform>().DetachChildren();
        Destroy(gameObject);
    }
}
