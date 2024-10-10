using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateStats : MonoBehaviour
{
    //put all the stats here - might change 
    public TextMeshProUGUI totalCurrency; 
    public TextMeshProUGUI maxHealthText;
    public TextMeshProUGUI maxStepsText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI ArmorText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI AttackText; 
    
    
    private PlayerStats playerStats;
    
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player"); //make sure we are getting player stats from player object 
        
        if (playerObject != null)
        {
            playerStats = playerObject.GetComponent<PlayerStats>();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats != null)
        {
            /* here is where we will access the stats to update - need to wait to see what all stats we need 
            totalCurrency; 
            maxHealthText = playerStats.totalCurrency.ToString();;
            maxStepsText;
            HPText;
            ArmorText;
            SpeedText;
            AttackText; 
            */
        }
    }
}
