using Unity.VisualScripting;
using UnityEngine;

public class CollectableStats : ScriptableObject
{
    [Header("Collectable stats")]
    [Tooltip("if its currency then don't keep the item")]
    public bool isCurrency;
    [Tooltip("Which item is it")]
    public int itemID; 
    
    [Range(0,100)]
    [Tooltip("How much the item is valued")]
    public int itemValue;


}
