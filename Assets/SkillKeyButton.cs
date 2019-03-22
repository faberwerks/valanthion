using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillKeyButton : MonoBehaviour {

    private Button button;

    public KeyCode keyCode;

    public byte skillId;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update() {
        if (Game.current.skills[skillId] == 0)
        {
            button.interactable = false;
        }
        else
        {
            switch (keyCode)
            {
                case KeyCode.A:
                    if ((byte)PlayerPrefs.GetInt("SkillAKey") == skillId)
                    {
                        button.interactable = false;
                    }
                    else
                    {
                        button.interactable = true;
                    }
                    break;
                case KeyCode.S:
                    if ((byte)PlayerPrefs.GetInt("SkillSKey") == skillId)
                    {
                        button.interactable = false;
                    }
                    else
                    {
                        button.interactable = true;
                    }
                    break;
                case KeyCode.D:
                    if ((byte)PlayerPrefs.GetInt("SkillDKey") == skillId)
                    {
                        button.interactable = false;
                    }
                    else
                    {
                        button.interactable = true;
                    }
                    break;
                case KeyCode.F:
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
    }

    // a method to set this as the skill's key
    public void SetAsKey()
    {
        InputManager.instance.SetKey(keyCode, skillId);
        button.interactable = false;
    }
}
