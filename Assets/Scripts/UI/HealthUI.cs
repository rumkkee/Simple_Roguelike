using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    // Update the count of health UI icons based on player's max health
    // Update this on start
    // Update this whenever the player's max health is changed
    // Update the players's current health whenever damaged or healed

    private List<Image> healthMarkers;
    private int healthNumUI = 0;

    public Image healthMarkerPrefab;

    // Initializes or adjusts the number of health markers
    public void setMaxHealthDisplayed(int maxHealth)
    {
        if (healthMarkers == null)
        {
            healthMarkers = new List<Image>();
        }

        // Adjust health markers to match maxHealth
        if (healthMarkers.Count < maxHealth)
        {
            while (healthMarkers.Count < maxHealth)
            {
                Image healthMarker = Instantiate(healthMarkerPrefab, this.transform);
                healthMarkers.Add(healthMarker);
            }
        }
        else if (healthMarkers.Count > maxHealth)
        {
            while (healthMarkers.Count > maxHealth)
            {
                Image healthMarker = healthMarkers[healthMarkers.Count - 1];
                healthMarkers.RemoveAt(healthMarkers.Count - 1);
                Destroy(healthMarker);
            }
        }

        // Update healthNumUI to reflect the maximum health
        healthNumUI = maxHealth;

        // Set all health markers to active color
        foreach (var healthMarker in healthMarkers)
        {
            healthMarker.color = Color.white;
        }
    }

    // Updates the displayed health markers based on current health
    public void setCurrentHealthDisplayed(int currentHealth)
    {
        if (healthNumUI == currentHealth) return;

        for (int i = 0; i < healthMarkers.Count; i++)
        {
            healthMarkers[i].color = (i < currentHealth) ? Color.white : Color.black;
        }

        healthNumUI = currentHealth;
    }

}
