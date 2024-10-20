using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This exists for saving
[CreateAssetMenu(fileName = "playerStatsObject", menuName = "Player Stats Object")]
public class PlayerStats : ScriptableObject
{
    // Exists for stats reasons
    public static long totalCurrency;
    // Again stats reasons
    public static long totalStepsTaken;
    // How many steps can the player take before getting thrown back to the start?
    // public int stepsAvaliable;
    // How many hits a player can take before zucking dying.
    // public int health; 
    // How much is our starting health? 
    public static int startingHealth;  
    // How much Armor does the player has? 
    public static int armorValue;  
    // How much is our starting armor
    public static int startingArmor;
    // Consumable list for storing consumables. 
    public static int startingAttack = 1;
    public static int startingSpeed = 1;
    public static double startingCurrency = 0.00;
    public static int startingStepsTaken = 0;
    public static int startingStepsAvailable = 0;

    //Values that Update over the course of the game:
    public static int health = 10;
    public static int attack = 1;
    public static int armor = 0;
    public static int speed = 1;
    // public double totalCurrency = 0.00;
    public static long stepsTaken = 0;
    public static int stepsAvaliable = 0;
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    // Items list for storing items.
    public List<HealthItem> healthItems = new List<HealthItem>();
    public List<DamageItem> damageItems = new List<DamageItem>();
    public List<ArmorItem> armorItems = new List<ArmorItem>();
    public List<SpeedItem> speedItems = new List<SpeedItem>();


}
