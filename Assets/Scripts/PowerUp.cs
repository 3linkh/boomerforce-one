using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class PowerUp : MonoBehaviour
{
     
    RigidbodyFirstPersonController rigidbodyFirstPersonController;
    PlayerHealth playerHealth;
    PickUpDetails pickUpDetails;
    WeaponBehaviour weaponBehaviour;
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); 
        weaponBehaviour = GetComponentInChildren<WeaponBehaviour>();
        rigidbodyFirstPersonController = GetComponent<RigidbodyFirstPersonController>();
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
                rigidbodyFirstPersonController.movementSettings.ForwardSpeed *= pickUpDetails.IncreaseMovementSpeed();
                weaponBehaviour.timeBetweenShots /= pickUpDetails.IncreaseFireSpeed();
                Destroy(other.gameObject);
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

    }

}

