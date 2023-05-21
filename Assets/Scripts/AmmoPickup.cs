using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    AudioSource pickUpAudioSource;
    
    private void Start() 
    {
        pickUpAudioSource = GetComponent<AudioSource>();    
    }
    void OnTriggerEnter(Collider other)
    {
        pickUpAudioSource.Play();
        if(other.gameObject.tag == "Player")
        {
            
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }    
    }
}

