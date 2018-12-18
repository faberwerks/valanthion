using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    /*
    public GameObject newGamePanel;
    public GameObject loadGamePanel;
    public GameObject creditsPanel;
    public GameObject exitPanel;

    private void Awake()
    {
        newGamePanel.SetActive(false);
        loadGamePanel.SetActive(false);
        creditsPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    // a =method to toggle a panel on/off
    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeInHierarchy);
    }
    */

    public enum MainMenu
    {
        MainMenu,
        NewGame,
        LoadGame,
        Credits
    }

    public MainMenu currentMenu;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        if (currentMenu == MainMenu.MainMenu)
        {
            GUILayout.Box("Valanthion");
            GUILayout.Space(10);

            if (GUILayout.Button("New Game"))
            {
                Game.current = new Game();
                currentMenu = MainMenu.NewGame;
            }

            if (GUILayout.Button("Load Game"))
            {
                SaveLoad.Load();
                currentMenu = MainMenu.LoadGame;
            }

            if (GUILayout.Button("Credits"))
            {
                currentMenu = MainMenu.Credits;
            }

            if (GUILayout.Button("Quit"))
            {
                Application.Quit();
            }
        }
        else if (currentMenu == MainMenu.NewGame)
        {
            GUILayout.Box("Name Your Save");
            GUILayout.Space(10);

            GUILayout.Label("Save");
            Game.current.saveName = GUILayout.TextField(Game.current.saveName, 20);

            if (GUILayout.Button("Save"))
            {
                SaveLoad.Save();
                SceneManager.LoadScene("DemoLevel2");
            }

            GUILayout.Space(10);
            if (GUILayout.Button("Cancel"))
            {
                currentMenu = MainMenu.MainMenu;
            }
        }
        else if (currentMenu == MainMenu.LoadGame)
        {
            GUILayout.Box("Load Game");
            GUILayout.Space(10);

            foreach (Game savedGame in SaveLoad.savedGames)
            {
                if (GUILayout.Button(savedGame.saveName))
                {
                    Game.current = savedGame;
                    SceneManager.LoadScene("SecondaryMainMenu");
                }
            }

            GUILayout.Space(10);
            if (GUILayout.Button("Cancel"))
            {
                currentMenu = MainMenu.MainMenu;
            }
        }
        else if (currentMenu == MainMenu.Credits)
        {
            GUILayout.Space(10);
            if (GUILayout.Button("Back"))
            {
                currentMenu = MainMenu.MainMenu;
            }
        }

        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
