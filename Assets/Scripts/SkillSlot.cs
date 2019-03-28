using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour {

    public Sprite[] skillIcons = new Sprite[6];

    private Image image;

    private SkillControl skillControl;

    private Color defaultColour = new Color(1, 1, 1, 1);
    private Color cooldownColour = new Color(0.5f, 0.5f, 0.5f, 1);

    public KeyCode skillSlotKey;

    // private int skillsUnlocked = 0;

    private byte skillId;

    private bool unbound;

	// Use this for initialization
	private void Start () {

        skillControl = GameObject.FindGameObjectWithTag("Player").GetComponent<SkillControl>();

        image = GetComponent<Image>();
        image.sprite = skillIcons[skillId];

        #region Commented
        //for (int i = 0; i < 6; i++)
        //{
        //    if (Game.current.skills[i] != 0)
        //    {
        //        skillsUnlocked++;
        //    }
        //}

        
        //switch (skillSlotKey)
        //{
        //    case KeyCode.A:
        //        if (skillsUnlocked < 1)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            skillId = (byte)PlayerPrefs.GetInt("AKeySkill");
        //            if (skillId < 6)
        //            {
        //                image.sprite = skillIcons[skillId];
        //            }
        //        }
        //        break;
        //    case KeyCode.S:
        //        if (skillsUnlocked < 2)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            skillId = (byte)PlayerPrefs.GetInt("SKeySkill");
        //            if (skillId < 6)
        //            {
        //                image.sprite = skillIcons[skillId];
        //            }
        //        }
        //        break;
        //    case KeyCode.D:
        //        if (skillsUnlocked < 3)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            skillId = (byte)PlayerPrefs.GetInt("DKeySkill");
        //            if (skillId < 6)
        //            {
        //                image.sprite = skillIcons[skillId];
        //            }
        //        }
        //        break;
        //    case KeyCode.F:
        //        if (skillsUnlocked < 4)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            skillId = (byte)PlayerPrefs.GetInt("FKeySkill");
        //            if (skillId < 6)
        //            {
        //                image.sprite = skillIcons[skillId];
        //            }
        //        }
        //        break;
        //}
        #endregion

        unbound = false;

        switch (skillSlotKey)
        {
            case KeyCode.A:
                if (PlayerPrefs.GetInt("AKeySkill") == 6)
                {
                    unbound = true;
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte) PlayerPrefs.GetInt("AKeySkill");
                }
                break;
            case KeyCode.S:
                if (PlayerPrefs.GetInt("SKeySkill") == 6)
                {
                    unbound = true;
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte)PlayerPrefs.GetInt("SKeySkill");
                }
                break;
            case KeyCode.D:
                if (PlayerPrefs.GetInt("DKeySkill") == 6)
                {
                    unbound = true;
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte)PlayerPrefs.GetInt("DKeySkill");
                }
                break;
            case KeyCode.F:
                if (PlayerPrefs.GetInt("FKeySkill") == 6)
                {
                    unbound = true;
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte)PlayerPrefs.GetInt("FKeySkill");
                }
                break;
        }
    }

    // Update is called once per frame
    private void Update () {
        #region Commented
        //switch (skillSlotKey)
        //{
        //    case KeyCode.A:
        //        if (skillsUnlocked < 1)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            if (skillControl.canUse[skillId])
        //            {
        //                image.color = defaultColour;
        //            }
        //            else
        //            {
        //                image.color = cooldownColour;
        //            }
        //        }
        //        break;
        //    case KeyCode.S:
        //        if (skillsUnlocked < 2)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            if (skillControl.canUse[skillId])
        //            {
        //                image.color = defaultColour;
        //            }
        //            else
        //            {
        //                image.color = cooldownColour;
        //            }
        //        }
        //        break;
        //    case KeyCode.D:
        //        if (skillsUnlocked < 3)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            if (skillControl.canUse[skillId])
        //            {
        //                image.color = defaultColour;
        //            }
        //            else
        //            {
        //                image.color = cooldownColour;
        //            }
        //        }
        //        break;
        //    case KeyCode.F:
        //        if (skillsUnlocked < 4)
        //        {
        //            image.color = cooldownColour;
        //        }
        //        else
        //        {
        //            if (skillControl.canUse[skillId])
        //            {
        //                image.color = defaultColour;
        //            }
        //            else
        //            {
        //                image.color = cooldownColour;
        //            }
        //        }
        //        break;
        //}
        #endregion

        if (!unbound)
        {
            CheckSlotState();
        }
    }

    // a method to check the current state of the slot
    private void CheckSlotState()
    {
        #region Commented
        //switch (skillSlotKey)
        //{
        //    case KeyCode.A:
        //        if (skillControl.cooldownTimers[skillId] <= 0)
        //        {
        //            image.color = defaultColour;
        //        }
        //        else
        //        {
        //            image.color = cooldownColour;
        //        }
        //        break;
        //    case KeyCode.S:
        //        if (skillControl.cooldownTimers[skillId] <= 0)
        //        {
        //            image.color = defaultColour;
        //        }
        //        else
        //        {
        //            image.color = cooldownColour;
        //        }
        //        break;
        //    case KeyCode.D:
        //        if (skillControl.cooldownTimers[skillId] <= 0)
        //        {
        //            image.color = defaultColour;
        //        }
        //        else
        //        {
        //            image.color = cooldownColour;
        //        }
        //        break;
        //    case KeyCode.F:
        //        if (skillControl.cooldownTimers[skillId] <= 0)
        //        {
        //            image.color = defaultColour;
        //        }
        //        else
        //        {
        //            image.color = cooldownColour;
        //        }
        //        break;
        //}
        #endregion

        if (skillControl.cooldownTimers[skillId] <= 0)
        {
            image.color = defaultColour;
        }
        else
        {
            image.color = cooldownColour;
        }
    }
}
