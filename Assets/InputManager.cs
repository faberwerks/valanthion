using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager instance;

    public byte SkillAKey { get; set; }
    public byte SkillSKey { get; set; }
    public byte SkillDKey { get; set; }
    public byte SkillFKey { get; set; }

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

        SkillAKey = (byte) PlayerPrefs.GetInt("SkillAKey", 0);
        SkillSKey = (byte) PlayerPrefs.GetInt("SkillSKey", 1);
        SkillDKey = (byte) PlayerPrefs.GetInt("SkillDKey", 2);
        SkillFKey = (byte) PlayerPrefs.GetInt("SkillFKey", 3);
    }
}
