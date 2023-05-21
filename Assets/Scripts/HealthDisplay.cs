using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    PlayerHealth playerHealth;
    public TextMeshProUGUI playerHealthText;

    public Slider slider;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        slider.value = playerHealth.hitPoints/playerHealth.hitPointsMax;
        playerHealthText.text = "HEALTH: " + playerHealth.hitPoints;
    }

    void Update()
    {
        slider.value = playerHealth.hitPoints/playerHealth.hitPointsMax;
        playerHealthText.text = "HEALTH: " + playerHealth.hitPoints;
        
    }
}
