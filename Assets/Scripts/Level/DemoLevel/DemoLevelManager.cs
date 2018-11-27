using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLevelManager : MonoBehaviour {

    private bool hasKey;
    private bool hasStone;

    // Use this for initialization
    void Start()
    {
        HasKey = false;
        HasStone = false;
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

    public bool HasStone
    {
        get
        {
            return hasStone;
        }
        set
        {
            this.hasStone = value;
        }
    }
}
