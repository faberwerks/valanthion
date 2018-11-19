using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public DemoLevelManager demoLevelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (demoLevelManager.HasKey == true || demoLevelManager.HasStone == true)
            {
                // whatever goes in here
            }
            else
            {
                // whatever goes in here
            }
        }
    }
}
