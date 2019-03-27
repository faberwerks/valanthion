using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipWeaponButton : MonoBehaviour {

    private Button buttonComponent;

    public int weaponId;

	// Use this for initialization
	private void Start () {
        buttonComponent = GetComponent<Button>();
	}
	
	// Update is called once per frame
	private void Update () {
        if (Game.current.weapons[weaponId] != 0 && Game.current.equippedWeaponID != weaponId)
        {
            buttonComponent.interactable = true;
        }
        else
        {
            buttonComponent.interactable = false;
        }
	}

    // a method to equip weapon
    public void EquipWeapon()
    {
        Game.current.equippedWeaponID = weaponId;
        Debug.Log(Game.current.equippedWeaponID);
    }
}
