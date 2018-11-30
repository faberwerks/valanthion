using UnityEngine;

[CreateAssetMenu()]
public class WeaponItem : ScriptableObject {
    public ushort itemId;
    public float attackStrength = 0;
    public float attackSpeed = 0;
    public float attackRange = 0;
}
