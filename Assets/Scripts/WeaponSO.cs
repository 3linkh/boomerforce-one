using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Custom/Weapon")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public string description;
    public bool automatic;
    public float damage;
    public float range;
    [Range(0.01f, 10f)]
    public float timeBetweenShots;
    public string ammoType; //might be able to change to class type instead of string

    public AudioClip fireSound; // might need fix WeaponBehaviour script if we have more than one sound clip. Such as reload sound; out of ammo sound etc.
    public GameObject projectilePrefab;
    public int maxAmmo;
    public float reloadTime;
}
