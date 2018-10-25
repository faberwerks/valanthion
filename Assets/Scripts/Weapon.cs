using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{

    GameManager GameManager;
    GetGameData GameData;

    string itemId = "002";

    int attack;
    int range;
    int attackSpeed;

    void Awake()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();
        GameData = GameManager.GetComponent<GetGameData>();
    }

    void Start()
    {
        foreach (string[] currString in GameData.itemList)
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
