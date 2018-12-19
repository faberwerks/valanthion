using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu()]
public class Skill : ScriptableObject {
    public ushort skillId;
    public string skillName;
    public Weapon.WeaponTypes weaponType;
    public byte skillNumber;
    public float cooldownTime = 0;
    public float executionTime = 0;
    public float staminaCost = 0;

    public bool dealsDamage = false;        
    public bool singleTarget = false;
    public bool multipleTargets = false;
    public bool bleeding = false;
    public float damageMultiplier = 0; // percentage of weapon's damage
    public float bleedingDamage = 0;

    public bool reducesDefense = false;

    public bool dashes = false;

    public bool slowsDownTarget = false;
    public bool stuns = false;
    public bool knocksBack = false;
    public bool cripples = false;

    public bool buffs = false;
    public bool attackStrength = false;
    public bool attackSpeed = false;
    public bool defense = false;
    public bool additionalHealth = false;
    public bool additionalStamina = false;

    public bool resetsCooldowns = false;
}
