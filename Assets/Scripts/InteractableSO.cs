using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item")]
public class InteractableSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool interactable;
    public string itemTag;
    public Canvas canvas;

}
