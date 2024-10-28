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
    public long totalCurrency;
    // Again stats reasons
    public long totalStepsTaken;
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
    public int startingStepsAvailable = 999;
    public int numberOfHealthPotions = 1;
    public int numberOfStepPotions = 1;
    public string Serialize()
    {
        StringBuilder retval = new StringBuilder();

        retval.Append(totalCurrency).Append(",")          // Append each field with a separator (comma)
              .Append(totalStepsTaken).Append(",")
              .Append(startingHealth).Append(",")
              .Append(armorValue).Append(",")
              .Append(startingArmor).Append(",")
              .Append(startingAttack).Append(",")
              .Append(startingSpeed).Append(",")
              .Append(startingCurrency).Append(",")
              .Append(startingStepsAvailable).Append(",")
              .Append(numberOfHealthPotions).Append(",")
              .Append(numberOfStepPotions);

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
        startingHealth = int.Parse(values[2]);
        armorValue = int.Parse(values[3]);
        startingArmor = int.Parse(values[4]);
        startingAttack = int.Parse(values[5]);
        startingSpeed = int.Parse(values[6]);
        startingCurrency = double.Parse(values[7]);
        startingStepsAvailable = int.Parse(values[8]);
        numberOfHealthPotions = int.Parse(values[9]);
        numberOfStepPotions = int.Parse(values[10]);
    }
}
