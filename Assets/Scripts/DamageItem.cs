using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DamageItemScriptableObject", menuName = "ScriptableObjects/DamageItem")]
public class DamageItem : ScriptableObject
{
    public int damage = 1; // Default damage

    public List<DamageItem> damageItems = new List<DamageItem>();

    // Reference to the damage tiers
    public DamageItem damageTier1;
    public DamageItem damageTier2;
    public DamageItem damageTier3;
    public DamageItem damageTier4;
    public DamageItem damageTier5;

    // This method initializes the list and assigns damage values
    public void InitializeDamageItems()
    {
        // Assign damage values to each tier
        damageTier1.damage = 1;
        damageTier2.damage = 2;
        damageTier3.damage = 3;
        damageTier4.damage = 4;
        damageTier5.damage = 5;

        // Initialize the list
        damageItems = new List<DamageItem>
        {
            damageTier1,
            damageTier2,
            damageTier3,
            damageTier4,
            damageTier5
        };
    }
}