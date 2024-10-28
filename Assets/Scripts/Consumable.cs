using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Consumable", menuName = "Consumable Object")]
public class Consumable : ScriptableObject
{
    public enum consumableType
    {
        healthPotion,
        damagePotion,
        stepPotion,
    }
    [Tooltip("What is it?")]
    public consumableType type;
    [Tooltip("How much is it?")]
    public int price;
    [Tooltip("How much does it change a stat?")]
    public int delta;
}
