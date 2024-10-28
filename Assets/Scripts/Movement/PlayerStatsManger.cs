using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStatsManager : MonoBehaviour
{
    public PlayerStats stats;
    public HealthUI healthUI;
    public CurrencyUI currencyUI;
    public StepCounterUI stepUI;
    public PotionUI potUI;
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
        potUI.updateSpeedPotDisplayed(stats.numberOfStepPotions);
        potUI.updateHealthPotDisplayed(stats.numberOfHealthPotions);
    }
    public void takeDamage(int amount, int enemySpeed)
    {
        currentHealth -= amount;
        currentHealth = Math.Max(currentHealth, 0);
        healthUI.setCurrentHealthDisplayed(currentHealth);
        StartCoroutine(FullscreenFXController.instance.Hurt());
        if(currentHealth == 0) {
            Debug.Log("Player Dies");
            PartcleManager.instance.makePartcleFX(PartcleManager.PartcleType.Blood, gameObject.transform.position);
            PlayerManager.instance.Movement.orient.setPlayerInvis();
            PlayerManager.instance.disableControls();
            StartCoroutine(transitionToMenu());
            SaveManger.instance.setSave(SaveManger.saveFileOne, stats);
        }
    }

    public void updateCurrency(int amount)
    {
        stats.totalCurrency += amount;
        currencyUI.updateCurrencyDisplayed(stats.totalCurrency);
    }

    public void updateSteps(int amount)
    {
        currentSteps -= amount;
        currentSteps = Math.Max(currentSteps, 0);
        stepUI.updateStepsDisplayed(currentSteps);
        if(currentSteps == 0) {
            Debug.Log("Player Dies");
            PartcleManager.instance.makePartcleFX(PartcleManager.PartcleType.Blood, gameObject.transform.position);
            PlayerManager.instance.disableControls();
            PlayerManager.instance.Movement.orient.setPlayerInvis();
            StartCoroutine(transitionToMenu());
            SaveManger.instance.setSave(SaveManger.saveFileOne, stats);
        }
    }

    public IEnumerator transitionToMenu()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void updatePotion() {
        string tmp = potUI.GetActivePotionType();
        if(tmp == "speed")  {
            if(stats.numberOfStepPotions <= 0) {
                return;
            }
            stats.numberOfStepPotions--;
            currentSteps += potUI.speedStats.delta;
            potUI.updateSpeedPotDisplayed(stats.numberOfStepPotions);
            stepUI.updateStepsDisplayed(currentSteps);
        }
        if(tmp == "health")  {
            if(stats.numberOfHealthPotions <= 0) {
                return;
            }
            stats.numberOfHealthPotions--;
            currentHealth += potUI.healthStats.delta;
            currentHealth = Math.Min(currentHealth, stats.startingHealth);
            potUI.updateHealthPotDisplayed(stats.numberOfHealthPotions);
            healthUI.setCurrentHealthDisplayed(currentHealth);
        }
    }
}