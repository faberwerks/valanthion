using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour {

    // a method to unlock a skill
	public void UnlockSkill(int skillId)
    {
        if (Game.current.skillPoints > 0)
        {
            Game.current.skills[skillId] = 1;
            Game.current.skillPoints--;
        }
    }

    // a method to load scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
