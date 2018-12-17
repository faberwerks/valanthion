using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.IsJumping = false;
        }
    }

}
