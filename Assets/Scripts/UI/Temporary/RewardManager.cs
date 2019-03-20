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
                //change rewardIcon
                break;
            case 4:
                rewardName.GetComponent<Text>().text = "Azelion";
                //change rewardIcon
                break;
        }
    }
}
