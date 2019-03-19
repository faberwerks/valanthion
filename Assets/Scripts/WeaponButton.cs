using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour {

    private Button buttonComponent;

    public int weaponId;

    // Use this for initialization
    private void Start()
    {
        buttonComponent = GetComponent<Button>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Game.current.weapons[weaponId] != 0)
        {
            buttonComponent.interactable = true;
        }
        else
        {
            buttonComponent.interactable = false;
        }
    }
}
