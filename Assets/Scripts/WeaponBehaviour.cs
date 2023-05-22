using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] WeaponSO weaponScriptableObject;

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    //[SerializeField] Ammo ammoSlot;
    //[SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    AudioSource weaponShotAudio;

    bool canShoot = true;

    private void Start() 
    {
        //weaponShotAudio = weaponScriptableObject.fireSound; TODO Fix this should be a clip I think
        range = weaponScriptableObject.range;
        damage = weaponScriptableObject.damage;
        timeBetweenShots = weaponScriptableObject.timeBetweenShots;
    }
    
    private void OnEnable() 
    {
        canShoot = true;
        weaponShotAudio = GetComponent<AudioSource>();
    }
   
    void Update()
    {
        DisplayAmmo();

        if (weaponScriptableObject.automatic)
        {
            if (Input.GetMouseButton(0) && canShoot == true)
            StartCoroutine(ShootAutomatic());
        }
        

        if (!weaponScriptableObject.automatic)
        {
            if (Input.GetMouseButtonDown(0) && canShoot == true)
            {          
                StartCoroutine(ShootSingle());  
            }
        }
        
        
    }
    private void DisplayAmmo()
    {
        //int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        //ammoText.text = currentAmmo.ToString();
    }

    IEnumerator ShootSingle () // change to shoot singlefire
    {
        canShoot = false;
        //if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            //PlayMuzzleFlash();
            weaponShotAudio.Play();
            ProcessRaycast();
            //ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
        
    }

    IEnumerator ShootAutomatic()
    {
       canShoot = false;
        //if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            //PlayMuzzleFlash();
            weaponShotAudio.Play();
            ProcessRaycast();
            //ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            Debug.Log("I hit: "+ hit.transform.name);
            if (target == null) return;
            
            //call a method on EnemyHealth that decreases the enemy's health
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
       GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 0.1f);
    }
}

