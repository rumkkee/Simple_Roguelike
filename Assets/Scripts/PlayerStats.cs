using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
// This exists for saving
[CreateAssetMenu(fileName = "playerStatsObject", menuName = "Player Stats Object")]
public class PlayerStats : ScriptableObject
{
    private const int NUM_OF_ITEMS = 12;
    // Exists for stats reasons
    public static long totalCurrency;
    // Again stats reasons
    public long totalStepsTaken;
    // How many steps can the player take before getting thrown back to the start?
    public int stepsAvaliable;
    // How many hits a player can take before zucking dying.
    public int health; 
    // How much is our starting health? 
    public int startingHealth;  
    // How much Armor does the player has? 
    public int armorValue;  
    // How much is our starting armor
    public int startingArmor;
    // Consumable list for storing consumables. 
    public int startingAttack = 1;
    public int startingSpeed = 1;
    public double startingCurrency = 0.00;
    public int startingStepsTaken = 0;
    public int startingStepsAvailable = 0;

    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    // Items list for storing items.

    // For now, we are ignoring items.. 
    public List<HealthItem> healthItems = new List<HealthItem>();
    public List<DamageItem> damageItems = new List<DamageItem>();
    public List<ArmorItem> armorItems = new List<ArmorItem>();
    public List<SpeedItem> speedItems = new List<SpeedItem>();

    public string Serialize()
    {
        StringBuilder retval = new StringBuilder();
        
        retval.Append(totalCurrency).Append(",")          // Append each field with a separator (comma)
              .Append(totalStepsTaken).Append(",")
              .Append(stepsAvaliable).Append(",")
              .Append(health).Append(",")
              .Append(startingHealth).Append(",")
              .Append(armorValue).Append(",")
              .Append(startingArmor).Append(",")
              .Append(startingAttack).Append(",")
              .Append(startingSpeed).Append(",")
              .Append(startingCurrency).Append(",")
              .Append(startingStepsTaken).Append(",")
              .Append(startingStepsAvailable);

        return retval.ToString();  // Return the concatenated string
    }

    public void Deserialize(string serializedData)
    {
        string[] values = serializedData.Split(',');

        if (values.Length < NUM_OF_ITEMS)
        {
            Debug.LogError($"Data length mismatch: expected {NUM_OF_ITEMS} elements.");
            return;
        }

        totalCurrency = long.Parse(values[0]);
        totalStepsTaken = long.Parse(values[1]);
        stepsAvaliable = int.Parse(values[2]);
        health = int.Parse(values[3]);
        startingHealth = int.Parse(values[4]);
        armorValue = int.Parse(values[5]);
        startingArmor = int.Parse(values[6]);
        startingAttack = int.Parse(values[7]);
        startingSpeed = int.Parse(values[8]);
        startingCurrency = double.Parse(values[9]);
        startingStepsTaken = int.Parse(values[10]);
        startingStepsAvailable = int.Parse(values[11]);
    }
}
