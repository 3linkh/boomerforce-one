using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestTracker : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Slider questProgressSlider;
    public float questTimeStart;
    public float questTimeLeft;  // Set the initial time left in seconds
    public bool questIsActive = false;
    public bool questComplete = false;

    public Canvas questCanvas;

    // Start is called before the first frame update
    void Start()
    {
        questTimeLeft = questTimeStart;
        questCanvas.enabled = false;
        questProgressSlider.maxValue = questTimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (questIsActive)
        {
            questCanvas.enabled = true;
            ShowQuestTimer();
            
            UpdateQuestSlider();
            UpdateQuestStatus();
        }
        if(!questIsActive)
        {
            questCanvas.enabled = false;

        }
        
    }
    void UpdateQuestStatus()
    {
        if (questTimeLeft <= 0) //TO ADD & player is alive
        {
            questComplete = true;
            questIsActive = false;
        }
    }

    void ShowQuestTimer()
    {
        questTimeLeft -= Time.deltaTime;
            
        int minutes = Mathf.FloorToInt(questTimeLeft / 60);
        int seconds = Mathf.FloorToInt(questTimeLeft % 60);

        string questTimeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = questTimeString;
    }

    void UpdateQuestSlider()
    {
        questProgressSlider.value = questTimeLeft; // quest tracker value starts at 0 so need to increase

    }
}
