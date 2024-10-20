using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpeedItemScriptableObject", menuName = "ScriptableObjects/SpeedItem")]
public class SpeedItem : ScriptableObject
{
    public int value = 1; // Default speed

    public List<SpeedItem> speedItems = new List<SpeedItem>();

    // Reference to the speed tiers
    public SpeedItem speedTier1;
    public SpeedItem speedTier2;
    public SpeedItem speedTier3;
    public SpeedItem speedTier4;
    public SpeedItem speedTier5;

    // This method initializes the list and assigns speed values
    public void InitializeSpeedItems()
    {
        // Assign speed values to each tier
        speedTier1.value = 1;
        speedTier2.value = 2;
        speedTier3.value = 3;
        speedTier4.value = 4;
        speedTier5.value = 5;

        // Initialize the list
        speedItems = new List<SpeedItem>
        {
            speedTier1,
            speedTier2,
            speedTier3,
            speedTier4,
            speedTier5
        };
    }
}