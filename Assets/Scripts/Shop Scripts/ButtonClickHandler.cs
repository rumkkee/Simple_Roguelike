using System;
using System.Collections;
using System.Collections.Generic;
using Ink;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public PlayerStats playerStats;
    public Consumable stepStats;
    public Consumable healthStats;
    public TextMeshProUGUI healthPrice;
    public TextMeshProUGUI stepPrice;
    public TextMeshProUGUI attackPrice;
    public TextMeshProUGUI healthPotion;
    public TextMeshProUGUI stepPotion;
    private int stepUpgradePrice;
    private int healthUpgradePrice;
    private int attackUpgradePrice;
    public BackToDungeon back;
    public int attackLimt = 10;
    public int healthLimit = 20;

    // Increase player's attack
    public void increaseAttack()
    {
        if (playerStats.totalCurrency >= attackUpgradePrice && playerStats.startingAttack < attackLimt)
        {
            playerStats.totalCurrency -= attackUpgradePrice;
            playerStats.startingAttack++;
            updatePriceAttack(); // Update the price for the next attack upgrade
        }
        else
        {
            Debug.Log("Not enough currency to upgrade attack!");
        }
    }

    public void increaseSteps()
    {
        if (playerStats.totalCurrency >= stepUpgradePrice)
        {
            playerStats.totalCurrency -= stepUpgradePrice;
            playerStats.startingStepsAvailable++;
            updatePriceAttack();
        }
        else
        {
            Debug.Log("Not enough currency to upgrade speed!");
        }
    }

    public void increaseHealth()
    {
        if (playerStats.totalCurrency >= healthUpgradePrice && playerStats.startingHealth < healthLimit)
        {
            playerStats.totalCurrency -= healthUpgradePrice;
            playerStats.startingHealth++;
            updatePriceHealth();
        }
        else
        {
            Debug.Log("Not enough currency to upgrade health!");
        }
    }
    public void buyHealthPotion()
    {
        if (playerStats.totalCurrency >= healthStats.price)
        {
            playerStats.totalCurrency -= healthStats.price;
            playerStats.numberOfHealthPotions++;
        }
        else
        {
            Debug.Log("Not enough currency to buy health potion!");
        }
    }

    public void buyStepPotion()
    {
        if (playerStats.totalCurrency >= stepStats.price)
        {
            playerStats.totalCurrency -= stepStats.price;
            playerStats.numberOfStepPotions++;
        }
        else
        {
            Debug.Log("Not enough currency to buy step potion!");
        }
    }

    public void updatePriceStep()
    {
        stepUpgradePrice = (int)(Math.Log(playerStats.startingStepsAvailable + 1) / 2) * 10 + 50;
        updateUIPrices();
    }

    public void updatePriceHealth()
    {
        healthUpgradePrice = (int)(Math.Pow(playerStats.startingHealth, 2) + 50);
        updateUIPrices();
    }

    public void updatePriceAttack()
    {
        attackUpgradePrice = (int)(Math.Pow(playerStats.startingSpeed, 3) + 50);
        updateUIPrices();
    }
    public void updateUIPrices()
    {
        healthPotion.text = "$" + healthStats.price.ToString();
        stepPrice.text = "$" + stepUpgradePrice.ToString();


        stepPotion.text = "$" + stepStats.price.ToString();
        if (playerStats.startingHealth >= healthLimit)
        {
            healthPrice.text = "SOLD OUT";
        }
        else
        {
            healthPrice.text = "$" + healthUpgradePrice.ToString();
        }
        if (playerStats.startingAttack >= attackLimt)
        {
            attackPrice.text = "SOLD OUT";
        }
        else
        {
            attackPrice.text = "$" + attackUpgradePrice.ToString();
        }
    }

    public void goBackToMain()
    {
        back.GoToDungeon();
    }

    private void Start()
    {
        updatePriceStep();
        updatePriceHealth();
        updatePriceAttack();
        updateUIPrices();
    }
}
