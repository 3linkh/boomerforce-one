using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hitPoints = 100f;
    public float hitPointsMax;
    AudioSource damageAudio;
    //AudioSource healthAudio;

private void Start() 
{
    damageAudio = GetComponent<AudioSource>();
    hitPointsMax = hitPoints;    
}
   
public void TakeDamage(float damage)
{
    hitPoints -= damage;
    damageAudio.Play();
    if (hitPoints <= 0)
    {
        //GetComponent<DeathHandler>().HandleDeath();
        
    }
}

public void GiveHealth(float health)
{
    if ((hitPoints + health)>=hitPointsMax)
    {
        hitPoints = hitPointsMax;
    }
    else if (hitPoints < hitPointsMax)
    {
        hitPoints += health;
        
    }
}
    
}