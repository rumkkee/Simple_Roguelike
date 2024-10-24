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
    private int currentHealth = 0;

    public Image healthMarkerPrefab;

    public void Start()
    {
        int maxHealth = PlayerManager.instance.stats.health;
        setMaxHealthDisplayed(maxHealth);
        currentHealth = maxHealth;

        int startingHealth = PlayerStats.startingHealth;
        setCurrentHealthDisplayed(startingHealth);

        PlayerStats.MaxHealthUpdated += setMaxHealthDisplayed;
        PlayerStats.StartingHealthUpdated += setCurrentHealthDisplayed;
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
        if (this.currentHealth == currentHealth)
        {
            return;
        }
        else if (this.currentHealth < currentHealth)
        {
            while (this.currentHealth != currentHealth)
            {
                Image topHealthMarker = healthMarkers[this.currentHealth - 1];
                topHealthMarker.color = Color.white;
                this.currentHealth++;
            }
        }
        else
        {
            while (this.currentHealth != currentHealth)
            {
                Image topHealthMarker = healthMarkers[this.currentHealth - 1];
                topHealthMarker.color = Color.gray;
                this.currentHealth--;
            }
            
        }
    }

    private void OnDestroy()
    {
        PlayerStats.MaxHealthUpdated -= setMaxHealthDisplayed;
        PlayerStats.StartingHealthUpdated -= setCurrentHealthDisplayed;
    }

}
