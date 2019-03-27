using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour {

    public GameObject rewardIcon;
    public GameObject rewardName;

    public void SetReward(int stage)
    {
        switch (stage)
        {
            case 2:
                rewardName.GetComponent<Text>().text = "Ryter Sword";
                Game.current.weapons[1] = 1;
                //change rewardIcon
                break;
            case 4:
                rewardName.GetComponent<Text>().text = "Azelion";
                Game.current.weapons[2] = 1;
                //change rewardIcon
                break;
        }
    }
}
