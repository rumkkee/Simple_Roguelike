using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ArmorItemScriptableObject", menuName = "ScriptableObjects/ArmorItem")]
public class ArmorItem : ScriptableObject
{
    public int armor = 1; // Default armor

    public List<ArmorItem> armorItems = new List<ArmorItem>();

    // Reference to the armor tiers
    public ArmorItem armorTier1;
    public ArmorItem armorTier2;
    public ArmorItem armorTier3;
    public ArmorItem armorTier4;
    public ArmorItem armorTier5;

    // This method initializes the list and assigns armor values
    public void InitializeArmorItems()
    {
        // Assign armor values to each tier
        armorTier1.armor = 1;
        armorTier2.armor = 2;
        armorTier3.armor = 3;
        armorTier4.armor = 4;
        armorTier5.armor = 5;

        // Initialize the list
        armorItems = new List<ArmorItem>
        {
            armorTier1,
            armorTier2,
            armorTier3,
            armorTier4,
            armorTier5
        };
    }
}