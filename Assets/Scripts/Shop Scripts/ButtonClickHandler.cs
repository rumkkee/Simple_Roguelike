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
    //Making all the items cost 2 gold for now, change up after playtesting.
    //Adding 3000 just to see change.
    public void OnButtonClick(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                Debug.Log("Button 0 clicked! Speaking to merchant!");
                // Add functionality for Merchant
                /*
                How do I handle dialogue...
                */
                break;
            
            case 1:
                Debug.Log("Button 1 clicked! Adding Health!");
                // Add functionality for Health++
                if (playerStats.startingCurrency >= 2) {
                    playerStats.health += 3000;
                    
                    //Decrement starting currency:
                    playerStats.startingCurrency -= 2;
                }
                break;
            case 2:
                Debug.Log("Button 2 clicked! Adding Steps!");
                // Add functionality for Steps++
                if (playerStats.startingCurrency >= 2) {
                    playerStats.steps += 3000;

                    //Decrement starting currency:
                    playerStats.startingCurrency -= 2;
                }
                break;
            case 3:
                Debug.Log("Button 3 clicked! Adding Speed!");
                // Add functionality for Speed++
                if (playerStats.startingCurrency >= 2) {
                    playerStats.speed += 3000;

                    //Decrement starting currency:
                    playerStats.startingCurrency -= 2;
                }
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
