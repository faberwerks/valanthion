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
        SkillSKey = (byte) PlayerPrefs.GetInt("SkillSKey", -1);
        SkillDKey = (byte) PlayerPrefs.GetInt("SkillDKey", -1);
        SkillFKey = (byte) PlayerPrefs.GetInt("SkillFKey", -1);
    }

    // a method to bind a key to a skill
    public void SetKey(KeyCode keyCode, byte skillId)
    {
        switch (keyCode)
        {
            case KeyCode.A:
                PlayerPrefs.SetInt("SkillAKey", skillId);
                SkillAKey = (byte)PlayerPrefs.GetInt("SkillAKey");
                break;
            case KeyCode.S:
                PlayerPrefs.SetInt("SkillSKey", skillId);
                SkillAKey = (byte)PlayerPrefs.GetInt("SkillSKey");
                break;
            case KeyCode.D:
                PlayerPrefs.SetInt("SkillDKey", skillId);
                SkillAKey = (byte)PlayerPrefs.GetInt("SkillDKey");
                break;
            case KeyCode.F:
                PlayerPrefs.SetInt("SkillFKey", skillId);
                SkillAKey = (byte)PlayerPrefs.GetInt("SkillFKey");
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log(PlayerPrefs.GetInt("SkillAKey"));
            Debug.Log(PlayerPrefs.GetInt("SkillSKey"));
            Debug.Log(PlayerPrefs.GetInt("SkillDKey"));
            Debug.Log(PlayerPrefs.GetInt("SkillFKey"));
            Debug.Log(Game.current.skills);
        }
    }
}
