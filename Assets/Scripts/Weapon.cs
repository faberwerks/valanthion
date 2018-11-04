using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameManager gameManager;
    private GameData gameData;

    private string itemId = "002";

    private int attack;
    private int range;
    private int attackSpeed;

    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameData = gameManager.GetComponent<GameData>();
    }

    void Start()
    {
        foreach (string[] currString in gameData.itemList)
        {
            if(string.Equals(itemId,currString[0]))
            {
                attack = int.Parse(currString[2]);
                range = int.Parse(currString[3]);
                attackSpeed = int.Parse(currString[4]);

                Debug.Log(currString[0]);
                Debug.Log(currString[1]);
                Debug.Log(attack);
                Debug.Log(range);
                Debug.Log(attackSpeed);
            }
        }
    } 
}
