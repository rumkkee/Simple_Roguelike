using System;
using System.Collections;
using UnityEngine;


public class PlayerStatsManager : MonoBehaviour
{
    public PlayerStats stats;
    public HealthUI healthUI;
    public CurrencyUI currencyUI;
    public StepCounterUI stepUI;
    public int currentHealth;
    public int currentSpeed;
    public int currentAttack;
    public int currentSteps;
    void Awake()
    {
        if (stats == null)
        {
            Debug.LogError("Stats is not assigned in inspector");
            return;
        }
        if (healthUI == null)
        {
            Debug.LogError("Health is not assigned in inspector");
            return;
        }
        if (currencyUI == null)
        {
            Debug.LogError("Currency is not assigned in inspector");
            return;
        }
        if (stepUI == null)
        {
            Debug.LogError("Steps is not assigned in inspector");
            return;
        }
        currentHealth = stats.startingHealth;
        currentAttack = stats.startingAttack;
        currentSpeed = stats.startingSpeed;
        currentSteps = stats.startingStepsAvailable;
        stepUI.updateStepsDisplayed(currentSteps);
        healthUI.setMaxHealthDisplayed(stats.startingHealth);
        currencyUI.updateCurrencyDisplayed(stats.totalCurrency);
    }
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Math.Max(currentHealth, 0);
        healthUI.setCurrentHealthDisplayed(currentHealth);
        if(currentHealth == 0) {
            Debug.Log("Player Dies");
        }
    }

    public void updateCurrency(int amount)
    {
        stats.totalCurrency += amount;
        currencyUI.updateCurrencyDisplayed(stats.totalCurrency);
    }

    public bool canBuyItem(int amount) {
        return (stats.totalCurrency - amount < 0) ? false : true;
    }

    public void updateSteps(int amount)
    {
        currentSteps -= amount;
        currentSteps = Math.Max(currentSteps, 0);
        stepUI.updateStepsDisplayed(currentSteps);
        if(currentSteps == 0) {
            Debug.Log("Player Dies");
        }
    }
}