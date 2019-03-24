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

    private int skillsUnlocked = 0;

    private byte skillId;

	// Use this for initialization
	private void Start () {

        skillControl = GameObject.FindGameObjectWithTag("Player").GetComponent<SkillControl>();

        image = GetComponent<Image>();

        for (int i = 0; i < 6; i++)
        {
            if (Game.current.skills[i] != 0)
            {
                skillsUnlocked++;
            }
        }

        switch (skillSlotKey)
        {
            case KeyCode.A:
                if (skillsUnlocked < 1)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte)PlayerPrefs.GetInt("AKeySkill");
                    image.sprite = skillIcons[skillId];
                }
                break;
            case KeyCode.S:
                if (skillsUnlocked < 2)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte)PlayerPrefs.GetInt("SKeySkill");
                    image.sprite = skillIcons[skillId];
                }
                break;
            case KeyCode.D:
                if (skillsUnlocked < 3)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte)PlayerPrefs.GetInt("DKeySkill");
                    image.sprite = skillIcons[skillId];
                }
                break;
            case KeyCode.F:
                if (skillsUnlocked < 4)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    skillId = (byte)PlayerPrefs.GetInt("FKeySkill");
                    image.sprite = skillIcons[skillId];
                }
                break;
        }
	}
	
	// Update is called once per frame
	private void Update () {
        switch (skillSlotKey)
        {
            case KeyCode.A:
                if (skillsUnlocked < 1)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    if (skillControl.canUse[skillId])
                    {
                        image.color = defaultColour;
                    }
                    else
                    {
                        image.color = cooldownColour;
                    }
                }
                break;
            case KeyCode.S:
                if (skillsUnlocked < 2)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    if (skillControl.canUse[skillId])
                    {
                        image.color = defaultColour;
                    }
                    else
                    {
                        image.color = cooldownColour;
                    }
                }
                break;
            case KeyCode.D:
                if (skillsUnlocked < 3)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    if (skillControl.canUse[skillId])
                    {
                        image.color = defaultColour;
                    }
                    else
                    {
                        image.color = cooldownColour;
                    }
                }
                break;
            case KeyCode.F:
                if (skillsUnlocked < 4)
                {
                    image.color = cooldownColour;
                }
                else
                {
                    if (skillControl.canUse[skillId])
                    {
                        image.color = defaultColour;
                    }
                    else
                    {
                        image.color = cooldownColour;
                    }
                }
                break;
        }
    }
}
