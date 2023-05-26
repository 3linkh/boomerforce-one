using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "Custom/PowerUp")]
public class PowerUpSO : ScriptableObject
{
    public string powerUpName;
    public string tag;
    public string description;
    public bool healingType;
    public bool damageType;
    public bool utilityType;
    public float healAmount;
    public float damageAmount;
    public float effectMultiplier;
    [Range(0.01f, 10f)]
    public float timeBetweenEffect;
    public float effectDuration;
    
    public AudioClip powerUpSound; // might need fix WeaponBehaviour script if we have more than one sound clip. Such as reload sound; out of ammo sound etc.
    public GameObject projectilePrefab;
    
}
