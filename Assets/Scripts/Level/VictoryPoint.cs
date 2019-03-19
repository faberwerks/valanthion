using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Victory();
            FindObjectOfType<StageManager>().WinLevel();
            //GameObject.FindGameObjectWithTag("Stage Manager").GetComponent<StageManager>().WinLevel();
            Game.current.latestStage += 1;
        }
    }
}
