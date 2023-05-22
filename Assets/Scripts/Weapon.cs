using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
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

    private void OnEnable() 
    {
        canShoot = true;
        weaponShotAudio = GetComponent<AudioSource>();
    }
   
    void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {          
            StartCoroutine(Shoot());  
        }
        
    }
    private void DisplayAmmo()
    {
        //int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        //ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot ()
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

