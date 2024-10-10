using UnityEngine;

public class RandomHealthItemSelector : MonoBehaviour
{
    // Reference to the HealthItem scriptable object
    public HealthItem healthItemScriptableObject;

    // Method to get a random HealthItem based on the generated random number
    public HealthItem GetRandomHealthItem()
    {
        // Generate a random number between 1 and 5 (inclusive)
        int randomNumber = Random.Range(1, 6);

        // Switch to return the appropriate HealthItem based on the random number
        switch (randomNumber)
        {
            case 1:
                return healthItemScriptableObject.heartTier1;
            case 2:
                return healthItemScriptableObject.heartTier2;
            case 3:
                return healthItemScriptableObject.heartTier3;
            case 4:
                return healthItemScriptableObject.heartTier4;
            case 5:
                return healthItemScriptableObject.heartTier5;
            default:
                return null; // Just in case, though this should never be reached
        }
    }
}
