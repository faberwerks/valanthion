using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperHouse : MonoBehaviour
{

    public DemoLevelManager demoLevelManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (demoLevelManager.HasStone == true)
            {
                GetComponent<BoxCollider2D>().isTrigger = true;
            }
            else
            {
                // whatever goes in here
            }
        }
    }
}

