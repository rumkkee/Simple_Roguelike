using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collectable", menuName = "Collectable Object")]
public class CollectableStats : ScriptableObject
{
    [Tooltip("The sprite the collectable uses")]
    public Sprite collectableSprite; 
    [Header("Collectable stats")]
    [Tooltip("Which item is it")]
    public string itemID; 
    public enum itemType {
        Currency,
        Item,
        Consumable,
    }
    public itemType type;

    [Header("Currency Settings")]
    [Tooltip("How much the item is valued")]
    public int itemValue;

    [Tooltip("Drop chance")]
    public int dropChance;
}
