using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float fadeDuration = 2f;  // Duration in seconds
    public SkinnedMeshRenderer objectRenderer; // Reference to the Renderer component of the object
    public float hitPoints = 100f;

    public bool isDead = false;

    private void Awake() 
    {
        objectRenderer = GetComponentInChildren<SkinnedMeshRenderer>();    
    }
    public bool IsDead()
    {
        return isDead;
    }
    
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        FadeEnemyToDeath();
    }

    void FadeEnemyToDeath()
    {
        StartCoroutine(FadeOut());
        
    }

    private IEnumerator FadeOut()
    {
        //TODO FIX THE FADER

        // Get the initial color of the object
        Color initialColor =  objectRenderer.material.color;

        // Calculate the target color with zero alpha (fully transparent)
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        // Calculate the rate of change per second
        float rate = 1f / fadeDuration;

        // Loop until the fade duration is reached
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Update the color gradually
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime * rate);
            objectRenderer.material.color = Color.Lerp(initialColor, targetColor, t);

            // Wait for the next frame
            yield return null;
        }

            // Ensure the object is fully transparent
            objectRenderer.material.color = targetColor;
            DestroyEnemyGameObject();
        }
    

    void DestroyEnemyGameObject()
    {
        Destroy(this.gameObject);
    }

}
