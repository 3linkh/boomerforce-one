using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractWithOther : MonoBehaviour
{
    [SerializeField] InteractableSO interactableSO;
    [SerializeField] string tagOfItemToInteractWith;
    
    public Canvas itemCanvas;
    

    void Start()
    {
        // other itemName;
        // public string itemDescription;
        // public bool interactable;
        // public string itemTag;
        // public Canvas canvas;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag(tagOfItemToInteractWith))
        {
            itemCanvas = other.GetComponentInChildren<Canvas>();
            itemCanvas.enabled = true;
                             
            
        }
    }
    
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("QuestItem"))
        {
            itemCanvas = other.GetComponentInChildren<Canvas>();
            itemCanvas.enabled = false;
        }    
    }

}

