using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ArmorItemScriptableObject", menuName = "ScriptableObjects/ArmorItem")]
public class ArmorItem : ScriptableObject
{
    public int value = 1; // Default armor

    public List<ArmorItem> armorItems = new List<ArmorItem>();

    // Reference to the armor tiers
    public static ArmorItem armorTier1;
    public static ArmorItem armorTier2;
    public static ArmorItem armorTier3;
    public static ArmorItem armorTier4;
    public static ArmorItem armorTier5;

    // This method initializes the list and assigns armor values
    public void InitializeArmorItems()
    {
        // Assign armor values to each tier
        armorTier1.value = 1;
        armorTier2.value = 2;
        armorTier3.value = 3;
        armorTier4.value = 4;
        armorTier5.value = 5;

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

    public ArmorItem randomArmor() {
        System.Random rnd = new System.Random();
        return armorTier1;
    }
}