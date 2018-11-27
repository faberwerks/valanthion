using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponItemList : ScriptableObject {
    public List<WeaponItem> weaponItemList = new List<WeaponItem>();
}
