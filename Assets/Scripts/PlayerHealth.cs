using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hitPoints = 100f;
    public float hitPointsMax;
    AudioSource damageAudio;

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
    
}