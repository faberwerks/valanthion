using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillKeyButton : MonoBehaviour {

    private Button button;

    public KeyCode keyCode;

    public byte skillId;

    private bool locked;

    private void Awake()
    {
        button = GetComponent<Button>();

        CheckButtonState();
    }

    private void Update()
    {
        CheckButtonState();
    }

    // a method to set this as the skill's key
    public void SetAsKey()
    {
        InputManager.instance.SetKey(keyCode, skillId);
        // SendMessageUpwards("CheckButtonState");
    }

    // a method to check the state of the button to see whether it should be on or not
    private void CheckButtonState()
    {
        if (Game.current.skills[skillId] == 0)
        {
            button.interactable = false;
            locked = true;
        }
        else
        {
            locked = false;
        }

        // Debug.Log(gameObject.name + ": CheckButtonState called.");
        if (!locked)
        {
            switch (keyCode)
            {
                case KeyCode.A:
                    if ((byte)PlayerPrefs.GetInt("AKeySkill") == skillId)
                    {
                        button.interactable = false;
                        // Debug.Log(gameObject.name + ", Skill ID " + skillId + ": FALSE because already set to A.");
                    }
                    else
                    {
                        button.interactable = true;
                    }
                    break;
                case KeyCode.S:
                    if ((byte)PlayerPrefs.GetInt("SKeySkill") == skillId)
                    {
                        button.interactable = false;
                        // Debug.Log(gameObject.name + ", Skill ID " + skillId + ": FALSE because already set to S.");
                    }
                    else
                    {
                        button.interactable = true;
                    }
                    break;
                case KeyCode.D:
                    if ((byte)PlayerPrefs.GetInt("DKeySkill") == skillId)
                    {
                        button.interactable = false;
                        // Debug.Log(gameObject.name + ", Skill ID " + skillId + ": FALSE because already set to D.");
                    }
                    else
                    {
                        button.interactable = true;
                    }
                    break;
                case KeyCode.F:
                    if ((byte)PlayerPrefs.GetInt("FKeySkill") == skillId)
                    {
                        button.interactable = false;
                        // Debug.Log(gameObject.name + ", Skill ID " + skillId + ": FALSE because already set to F.");
                    }
                    else
                    {
                        button.interactable = true;
                    }
                    break;
            }
        }
    }
}
