using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public DemoLevelManager demoLevelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            demoLevelManager.HasStone = true;
            Destroy(gameObject);
        }
    }
}
