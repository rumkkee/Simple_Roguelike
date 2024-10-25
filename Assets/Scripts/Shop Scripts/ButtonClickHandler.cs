using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    private PlayerStats playerStats;
    public enum ButtonType
    {
        BuyHealth,
        BuySteps,
        BuyArmour,
        BuySpeed,
        ExitShop,
        BuyRandom1,
        BuyRandom2,
        BuyRandom3,
        SpeakMerchant
    }

    
    // Method that accepts a parameter to handle different button clicks
    public void OnButtonClick(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                Debug.Log("Button 0 clicked! Speaking to merchant!");
                // Add functionality for Merchant
                //playerStats.
                break;
            
            case 1:
                Debug.Log("Button 1 clicked! Adding Health!");
                // Add functionality for Health++
                //playerStats.he
                break;
            case 2:
                Debug.Log("Button 2 clicked! Adding Steps!");
                // Add functionality for Steps++
                break;
            case 3:
                Debug.Log("Button 3 clicked! Adding Speed!");
                // Add functionality for Speed++
                break;
    
            case 4:
                Debug.Log("Button 5 clicked! Exiting to shop!");
                // Add functionality for exit screen
                break;
            
            
            default:
                Debug.Log("Unknown button clicked!");
                break;
        }
    }

    
}
