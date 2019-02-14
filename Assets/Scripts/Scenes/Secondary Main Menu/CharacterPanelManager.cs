using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelManager : MonoBehaviour {

    public Text saveName;
    public Text maxHealth;
    public Text maxStamina;
    public Text skillPoints;
    public Text perkPoints;

    public Text temporarySkillPointsText;

    private int[] temporarySkills;
    private int temporarySkillPoints;

	// Use this for initialization
	void Awake () {
        saveName.text = Game.current.saveName;

        UpdateData();

        temporarySkillPointsText.text = Game.current.skillPoints.ToString();
        temporarySkillPoints = Game.current.skillPoints;

        temporarySkills = Game.current.skills;
	}
	
	// a method to update character data
    public void UpdateData()
    {
        // There should be code that determines max health and stamina based on
        // unlocked perks here
        maxHealth.text = "100";
        maxStamina.text = "100";

        skillPoints.text = Game.current.skillPoints.ToString();
        perkPoints.text = Game.current.perkPoints.ToString();
    }

    // a method to subtract skill points by one
    public void SubtractSkillPoint()
    {
        temporarySkillPoints--;
        temporarySkillPointsText.text = temporarySkillPoints.ToString();
    }

    // a method to unlock a skill
    public void UnlockSkill(int skillIndex)
    {
        if (skillIndex < temporarySkills.Length && temporarySkills[skillIndex] <= 3)
        {
            temporarySkills[skillIndex]++;
            SubtractSkillPoint();
        }
    }

    /*
     * CHARACTER PANEL SPECIFIC METHODS
     */
    // a method to save changes made to the skill tree 
    public void SaveSkillChanges()
    {
        Game.current.skillPoints = temporarySkillPoints;
        Game.current.skills = temporarySkills;
        UpdateData();
    }

    // a method to cancel changes made to the skill tree
    public void ResetSkillChanges()
    {
        temporarySkillPoints = Game.current.skillPoints;
        temporarySkills = Game.current.skills;
    }
}
