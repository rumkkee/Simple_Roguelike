using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This exists for saving
[CreateAssetMenu(fileName = "playerStatsObject", menuName = "Player Stats Object")]
public class PlayerStats : ScriptableObject
{
    // Exists for stats reasons
    public long totalCurrency;
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
    // Items list for storing items.
}
