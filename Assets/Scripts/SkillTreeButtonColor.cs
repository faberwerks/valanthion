using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeButtonColor : MonoBehaviour {

    private Button buttonComponent;

    private ColorBlock buttonCB;

    public ColorBlock unlockable;
    public ColorBlock notUnlockable;

    public int prevId;
    public int prevId2;

    public bool hasTwoRequirements;

    // Use this for initialization
    private void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonCB = buttonComponent.colors;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasTwoRequirements)
        {
            if (Game.current.skills[prevId] != 0)
            {
                buttonComponent.colors = unlockable;
            }
            else
            {
                buttonComponent.colors = notUnlockable;
            }
        }
        else
        {
            if (Game.current.skills[prevId] != 0 || Game.current.skills[prevId2] != 0)
            {
                buttonComponent.colors = unlockable; ;
            }
            else
            {
                buttonComponent.colors = notUnlockable;
            }
        }
    }
}
