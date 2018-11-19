using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLevelManager : MonoBehaviour {

    private bool hasKey;

    // Use this for initialization
    void Start()
    {
        HasKey = false;
    }

    /////// PROPERTIES ///////
    public bool HasKey
    {
        get
        {
            return hasKey;
        }
        set
        {
            this.hasKey = value;
        }
    }
}
