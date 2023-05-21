using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    AudioSource damageAudio;

private void Start() 
{
    damageAudio = GetComponent<AudioSource>();    
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