using UnityEngine;

[CreateAssetMenu()]
public class WeaponItem : ScriptableObject {
    public ushort itemId;
    public float attackStrength;
    public float attackSpeed;
    public float attackRange;
}
