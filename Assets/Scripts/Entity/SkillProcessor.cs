using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProcessor : MonoBehaviour {
    public SkillList skillList;

    private Weapon weapon;

    //private List<Skill> validSkillList = new List<Skill>();

    //private void Start()
    //{
    //    weapon = GetComponent<Weapon>();

    //    foreach (Skill skill in skillList.skillList)
    //    {
    //        if (skill.weaponType == weapon.WeaponType)
    //        {
    //            validSkillList.Add(skill);
    //        }
    //    }
    //}

    // a method to return the skill
    public Skill GetSkill(byte skillNumber)
    {
        foreach (Skill skill in skillList.skillList)
        {
            if (skill.skillNumber == skillNumber)
            {
                if (Game.current.skills[skillNumber] != 0)
                {
                    Debug.Log("Skill found: " + skill.skillName);
                    return skill;
                }
                else
                {
                    Debug.Log("LOCKED Skill found: " + skill.skillName);
                    return null;
                }
            }
        }

        return null;
    }
}
