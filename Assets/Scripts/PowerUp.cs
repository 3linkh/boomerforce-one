using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class PowerUp : MonoBehaviour
{
     
    RigidbodyFirstPersonController rigidbodyFirstPersonController;
    PlayerHealth playerHealth;
    PickUpDetails pickUpDetails;
    WeaponBehaviour weaponBehaviour;
    public Slider powerUpSlider;
    public bool powerUpIsActive = false;
    
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); 
        weaponBehaviour = GetComponentInChildren<WeaponBehaviour>();
        rigidbodyFirstPersonController = GetComponent<RigidbodyFirstPersonController>();
        powerUpIsActive = false;
    }
    private void Update()
    {   
        PowerUpTimer();
    }
    private void OnTriggerEnter(Collider other) 
    {
        pickUpDetails = other.gameObject.GetComponent<PickUpDetails>();
        print(pickUpDetails.powerUpSO);
        
        if(other.gameObject.tag == "PowerUp" && pickUpDetails.powerUpSO.healingType)
            {
                    UsePowerUpTypeHeal();
                    Destroy(other.gameObject);
            }
        else if (other.gameObject.tag == "PowerUp" && pickUpDetails.powerUpSO.utilityType)
            {
                UsePowerUpTypeUtility();
                Destroy(other.gameObject);
                powerUpIsActive = true;
            }
            
        }
    public void UsePowerUpTypeHeal()
    {
        playerHealth.GiveHealth(pickUpDetails.powerUpSO.healAmount);

    }

    public void UsePowerUpTypeDamage()
    {

    }

    public void UsePowerUpTypeUtility()
    {
        rigidbodyFirstPersonController.movementSettings.ForwardSpeed *= pickUpDetails.IncreaseMovementSpeed();
        weaponBehaviour.timeBetweenShots /= pickUpDetails.IncreaseFireSpeed();
    }
    public void PowerUpTimer()
    {
        if(powerUpIsActive)
        {
            powerUpSlider.enabled = true;
            pickUpDetails.GetPowerUpDuration() -= Time.deltaTime;
            powerUpSlider.value = pickUpDetails.powerUpDuration;
            if (pickUpDetails.powerUpDuration <= 0)
            {
                powerUpIsActive = false;
            }
        }
        else
        {
            powerUpSlider.enabled = false;
        }
        
    }

}

