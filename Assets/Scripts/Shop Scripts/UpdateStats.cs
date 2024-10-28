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
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI healthPotionNum;
    public TextMeshProUGUI stepPotionNum;
    public PlayerStats playerStats;

    // Update is called once per frame
    void Update()
    {
        totalCurrency.text = "$" + playerStats.totalCurrency.ToString();
        maxHealthText.text = playerStats.startingHealth.ToString();
        maxStepsText.text = playerStats.startingStepsAvailable.ToString();
        AttackText.text = playerStats.startingAttack.ToString();
        healthPotionNum.text = playerStats.numberOfHealthPotions.ToString();
        stepPotionNum.text = playerStats.numberOfStepPotions.ToString();
    }
}
