using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainMenuManager : MonoBehaviour {

	public enum GameMenu
    {
        GameMenu,
        SelectStage,
        Character,
    }

    public enum CharacterMenu
    {
        Character,
        Weapons,
        Armor,
        SkillsAndPerks
    }

    public GameMenu currentMenu;
    public CharacterMenu currentCharacterMenu;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        if (currentMenu == GameMenu.GameMenu)
        {
            GUILayout.Box("Valanthion");
            GUILayout.Space(10);

            if (GUILayout.Button("Continue Game"))
            {
                SceneManager.LoadScene(2 + Game.current.currentStage);  // 2 because the build index for stages start at 3
            }

            if (GUILayout.Button("Select Stage"))
            {
                currentMenu = GameMenu.SelectStage;
            }
            
            if (GUILayout.Button("Character"))
            {
                currentMenu = GameMenu.Character;
            }

            if (GUILayout.Button("Return to Main Menu"))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (currentMenu == GameMenu.SelectStage)
        {
            GUILayout.Box("Unlocked Stages");
            GUILayout.Space(10);

            for (int i = 1; i <= Game.current.currentStage; i++)
            {
                if (GUILayout.Button("Stage " + i))
                {
                    SceneManager.LoadScene(2 + i);
                }
            }

            GUILayout.Space(10);
            if (GUILayout.Button("Cancel"))
            {
                currentMenu = GameMenu.GameMenu;
            }
        }
        else if (currentMenu == GameMenu.Character)
        {
            if (currentCharacterMenu == CharacterMenu.Character)
            {
                // GUILayout.Label("Experience Points: ");
                // GUILayout.Box(Game.current.exp.ToString());

                GUILayout.Space(10);
                if (GUILayout.Button("Weapons"))
                {
                    currentCharacterMenu = CharacterMenu.Weapons;
                }

                if (GUILayout.Button("Armor"))
                {
                    currentCharacterMenu = CharacterMenu.Armor;
                }

                if (GUILayout.Button("Skills and Perks"))
                {
                    currentCharacterMenu = CharacterMenu.SkillsAndPerks;
                }

                GUILayout.Space(10);
                if (GUILayout.Button("Back"))
                {
                    currentMenu = GameMenu.GameMenu;
                }
            }
            else if (currentCharacterMenu == CharacterMenu.Weapons)
            {
                if (GUILayout.Button("Back"))
                {
                    currentCharacterMenu = CharacterMenu.Character;
                }
            }
            else if (currentCharacterMenu == CharacterMenu.Armor)
            {
                if (GUILayout.Button("Back"))
                {
                    currentCharacterMenu = CharacterMenu.Character;
                }
            }
            else if (currentCharacterMenu == CharacterMenu.SkillsAndPerks)
            {
                GUILayout.Label("Skill Points: ");
                GUILayout.Box(Game.current.skillPoints.ToString());
                GUILayout.Label("Skill Points: ");
                GUILayout.Box(Game.current.perkPoints.ToString());

                GUILayout.Space(10);
                if (GUILayout.Button("Back"))
                {
                    currentCharacterMenu = CharacterMenu.Character;
                }
            }
        }

        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
