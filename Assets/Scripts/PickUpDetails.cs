using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetails : MonoBehaviour
{
    public PowerUpSO powerUpSO;
    float healAmount;
    float speedMultiplier;
    private void Awake() 
    {
        speedMultiplier = powerUpSO.effectMultiplier;
        healAmount = powerUpSO.healAmount;
        //gameObject.tag = powerUpSO.tag;
        
    }

    public float HealPlayer()
    {
        return healAmount;
    }
    public float IncreaseMovementSpeed()
    {
        return speedMultiplier;
    }

    public float IncreaseFireSpeed()
    {
        return speedMultiplier;
    }



}
