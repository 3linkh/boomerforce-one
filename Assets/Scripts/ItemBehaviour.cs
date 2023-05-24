using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemBehaviour : MonoBehaviour
{
    Canvas itemCanvas;
    public TextMeshProUGUI itemText;
    public bool itemIsInteractable = true;
    
    public Color targetColor;  
    private Renderer sphereRenderer;  
    public bool gameobjectToBeDestroyed;

    public QuestTracker questTracker;

    void Start()
    {
        itemCanvas = GetComponentInChildren<Canvas>();
        itemCanvas.enabled = false;
        sphereRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if(itemIsInteractable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ItemActivation();
            }
        } 
    }

    public void ItemActivation()
    {
        if(itemCanvas.enabled)
        {
            {
                
                print("Activiting this game object");
                itemIsInteractable = false;
                questTracker.questIsActive = true;
                
                if (gameobjectToBeDestroyed)
                {
                    Invoke("DestroyTheGameObject", 2f);
                }
                else
                {
                    sphereRenderer.material.color = targetColor;
                }
            }
        }
        
    }

    void DestroyTheGameObject()
    {
        Destroy(this.gameObject);
    }
   
}
