using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillKeyButton : MonoBehaviour {

    private Button button;

    public string key;

    public byte skillId;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update() {
        switch (key)
        {
            case "A":
                if ((byte)PlayerPrefs.GetInt("SkillAKey") == skillId)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
                break;
            case "S":
                if ((byte)PlayerPrefs.GetInt("SkillSKey") == skillId)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
                break;
            case "D":
                if ((byte)PlayerPrefs.GetInt("SkillDKey") == skillId)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
                break;
            case "F":
                if ((byte)PlayerPrefs.GetInt("SkillFKey") == skillId)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
                break;
        }
    }

    // a method to set this as the skill's key
    public void SetAsKey()
    {
        InputManager.instance.SetKey(key, skillId);
        button.interactable = false;
    }
}
