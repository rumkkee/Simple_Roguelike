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

    public void Start()
    {
        // int maxHealth = PlayerManager.instance.currentHealth;
        // setMaxHealthDisplayed(maxHealth);
        // healthNumUI = maxHealth;

        // int startingHealth = .;
        // setCurrentHealthDisplayed(startingHealth);
    }

    public void setMaxHealthDisplayed(int maxHealth)
    {
        if (healthMarkers == null)
        {
            healthMarkers = new List<Image>();
        }

        if (healthMarkers.Count == maxHealth)
        {
            return;
        }
        else if (healthMarkers.Count < maxHealth)
        {
            while (healthMarkers.Count != maxHealth)
            {
                Image healthMarker = Instantiate(healthMarkerPrefab, this.transform);
                healthMarkers.Add(healthMarker);
            }
        }
        else
        {
            while (healthMarkers.Count != maxHealth)
            {

                Image healthMarker = healthMarkers[healthMarkers.Count - 1];
                healthMarkers.Remove(healthMarker);
                Destroy(healthMarker);

            }
        }
    }

    public void setCurrentHealthDisplayed(int currentHealth)
    {
        if (healthNumUI == currentHealth)
        {
            return;
        }
        else if (healthNumUI < currentHealth)
        {
            while (healthNumUI != currentHealth)
            {
                Image topHealthMarker = healthMarkers[healthNumUI - 1];
                topHealthMarker.color = Color.white;
                healthNumUI++;
            }
        }
        else
        {
            while (healthNumUI != currentHealth)
            {
                Image topHealthMarker = healthMarkers[healthNumUI - 1];
                topHealthMarker.color = Color.black;
                healthNumUI--;
            }
            
        }
    }

    private void OnDestroy()
    {
        // PlayerStats.MaxHealthUpdated -= setMaxHealthDisplayed;
        // PlayerStats.StartingHealthUpdated -= setCurrentHealthDisplayed;
    }

}
