using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionUI : MonoBehaviour
{
    public GameObject speedPotUI;
    public Consumable speedStats;
    public GameObject healthPotUI;
    public Consumable healthStats;
    public TextMeshProUGUI speedPotText;
    public TextMeshProUGUI healthPotUIText;

    // Returns the currently active potion type as a string
    public string GetActivePotionType()
    {
        return speedPotUI.activeInHierarchy ? "speed" : "health";
    }

    // Toggles the active UI between speed and health potions
    public void ToggleActivePotionUI()
    {
        bool isSpeedActive = speedPotUI.activeInHierarchy;

        speedPotUI.SetActive(!isSpeedActive);
        healthPotUI.SetActive(isSpeedActive);
    }

    public void updateSpeedPotDisplayed(int speedPot)
    {
        speedPotText.text = speedPot.ToString();
    }

    public void updateHealthPotDisplayed(int healthPot)
    {
        healthPotUIText.text = healthPot.ToString();
    }
}
