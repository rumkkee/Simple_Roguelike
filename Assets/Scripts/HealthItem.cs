using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthItemScriptableObject", menuName = "ScriptableObjects/HealthItem")]
public class HealthItem : ScriptableObject
{
    public int health = 1; // Default health

    public List<HealthItem> healthItems = new List<HealthItem>();

    // Reference to the health tiers
    public HealthItem heartTier1;
    public HealthItem heartTier2;
    public HealthItem heartTier3;
    public HealthItem heartTier4;
    public HealthItem heartTier5;

    // This method initializes the list and assigns health values
    public void InitializeHealthItems()
    {
        // Assign health values to each tier
        heartTier1.health = 1;
        heartTier2.health = 2;
        heartTier3.health = 3;
        heartTier4.health = 4;
        heartTier5.health = 5;

        // Initialize the list
        healthItems = new List<HealthItem>
        {
            heartTier1,
            heartTier2,
            heartTier3,
            heartTier4,
            heartTier5
        };
    }
}
