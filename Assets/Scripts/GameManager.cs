using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState : byte { Start, Defeat, Victory };

    Player player;

    protected byte state;

    protected GameObject[] enemies;

    // Use this for initialization
    void Start () {
        SetState((byte)GameState.Start);

        player = GameObject.FindObjectOfType<Player>();
	}

    // Update is called once per frame
    void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length < 1)
        {
            SetState((byte)GameState.Victory);
        }

		switch (GetState())
        {
            case (byte)GameState.Defeat:
                Debug.Log("DEFEAT BOI");
                break;
            case (byte)GameState.Victory:
                Debug.Log("Victory Boy");
                break;
        }
	}

    // this function is used to give the player exp
    public void Exp(int expValue)
    {
        player.SetExp(expValue);
    }

    public void SetState(byte state)
    {
        this.state = state;
    }

    public byte GetState()
    {
        return this.state;
    }
}
