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
        currentSpeed = stats.startingStepsAvailable;
    }
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Math.Min(currentHealth, 0);
    }

    public void updateCurrency(int amount)
    {
        stats.totalCurrency += amount;
        currencyUI.updateCurrencyDisplayed(stats.totalCurrency);

    }

    public void updateSteps(int amount)
    {

    }
}