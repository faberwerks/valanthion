using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager instance;

    public byte AKeySkill { get; set; }
    public byte SKeySkill { get; set; }
    public byte DKeySkill { get; set; }
    public byte FKeySkill { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        #region Commented
        //// gets existing key bindings if they exist
        //// if not assigns Skill ID 0 to all keys by default
        //AKeySkill = (byte) PlayerPrefs.GetInt("AKeySkill", 0);
        //SKeySkill = (byte) PlayerPrefs.GetInt("SKeySkill", 6);
        //DKeySkill = (byte) PlayerPrefs.GetInt("DKeySkill", 6);
        //FKeySkill = (byte) PlayerPrefs.GetInt("FKeySkill", 6);
        #endregion
    }

    // a method to bind a skill to a key
    public void SetKey(KeyCode keyCode, byte skillId)
    {
        switch (keyCode)
        {
            case KeyCode.A:
                PlayerPrefs.SetInt("AKeySkill", skillId);
                AKeySkill = (byte)PlayerPrefs.GetInt("AKeySkill");
                break;
            case KeyCode.S:
                PlayerPrefs.SetInt("SKeySkill", skillId);
                SKeySkill = (byte)PlayerPrefs.GetInt("SKeySkill");
                break;
            case KeyCode.D:
                PlayerPrefs.SetInt("DKeySkill", skillId);
                DKeySkill = (byte)PlayerPrefs.GetInt("DKeySkill");
                break;
            case KeyCode.F:
                PlayerPrefs.SetInt("FKeySkill", skillId);
                FKeySkill = (byte)PlayerPrefs.GetInt("FKeySkill");
                break;
        }

        RemoveDuplicateKeyBindings(keyCode, skillId);
    }

    // a method to remove duplicate and/or old key bindings after a new key binding has been set
    private void RemoveDuplicateKeyBindings(KeyCode baseKeyCode, byte skillId)
    {
        if (baseKeyCode != KeyCode.A)
        {
            if (AKeySkill == skillId)
            {
                PlayerPrefs.SetInt("AKeySkill", 6);
                AKeySkill = (byte)PlayerPrefs.GetInt("AKeySkill");
            }
        }

        if (baseKeyCode != KeyCode.S)
        {
            if (SKeySkill == skillId)
            {
                PlayerPrefs.SetInt("SKeySkill", 6);
                SKeySkill = (byte)PlayerPrefs.GetInt("SKeySkill");
            }
        }

        if (baseKeyCode != KeyCode.D)
        {
            if (DKeySkill == skillId)
            {
                PlayerPrefs.SetInt("DKeySkill", 6);
                DKeySkill = (byte)PlayerPrefs.GetInt("DKeySkill");
            }
        }

        if (baseKeyCode != KeyCode.F)
        {
            if (FKeySkill == skillId)
            {
                PlayerPrefs.SetInt("FKeySkill", 6);
                FKeySkill = (byte)PlayerPrefs.GetInt("FKeySkill");
            }
        }
    }

    public void SetKeysFromSaveFile(byte[] skillKeys)
    {
        SetKey(KeyCode.A, skillKeys[0]);
        SetKey(KeyCode.S, skillKeys[1]);
        SetKey(KeyCode.D, skillKeys[2]);
        SetKey(KeyCode.F, skillKeys[3]);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("A Key Skill: " + PlayerPrefs.GetInt("AKeySkill"));
            Debug.Log("S Key Skill: " + PlayerPrefs.GetInt("SKeySkill"));
            Debug.Log("D Key Skill: " + PlayerPrefs.GetInt("DKeySkill"));
            Debug.Log("F Key Skill: " + PlayerPrefs.GetInt("FKeySkill"));
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            SetKey(KeyCode.A, 0);
            SetKey(KeyCode.S, 6);
            SetKey(KeyCode.D, 6);
            SetKey(KeyCode.F, 6);
        }

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            Game.current.latestStage = 6;
        }

    }
}
