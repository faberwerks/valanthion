using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveList : ScriptableObject {

    public List<PlayerSave> SaveData = new List<PlayerSave>();
}
