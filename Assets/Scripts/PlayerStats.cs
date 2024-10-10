using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This exists for saving
[CreateAssetMenu(fileName = "playerStatsObject", menuName = "Player Stats Object")]
public class PlayerStats : ScriptableObject
{
    //Starting Values (Use for New Game):
    public int startingHealth = 10;  
    public int startingAttack = 1;
    public int startingArmor = 0;
    public int startingSpeed = 1;
    public double startingCurrency = 0.00;
    public int startingStepsTaken = 0;
    public int startingStepsAvailable = 0;


    //Values that Update over the course of the game:
    public int health = 10;
    public int attack = 1;
    public int armor = 0;
    public int speed = 1;
    public double totalCurrency = 0.00;
    public long stepsTaken = 0;
    public int stepsAvaliable = 0;
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-




    // Consumable list for storing consumables.
    ArrayList consumablesArrList = new ArrayList();

    // Items list for storing items.
    public List<HealthItem> healthItems = new List<HealthItem>();
    public List<DamageItem> damageItems = new List<DamageItem>();
    public List<ArmorItem> armorItems = new List<ArmorItem>();
    public List<SpeedItem> speedItems = new List<SpeedItem>();


}
