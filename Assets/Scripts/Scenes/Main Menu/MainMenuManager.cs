using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

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
}
