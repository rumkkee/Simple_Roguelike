using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpeedItemScriptableObject", menuName = "ScriptableObjects/SpeedItem")]
public class SpeedItem : ScriptableObject
{
    public int speed = 1; // Default speed

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
        speedTier1.speed = 1;
        speedTier2.speed = 2;
        speedTier3.speed = 3;
        speedTier4.speed = 4;
        speedTier5.speed = 5;

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