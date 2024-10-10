using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{

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
                break;
            
            
            
            case 1:
                Debug.Log("Button 1 clicked! Adding health");
                // Add functionality for Health++
                break;
            case 2:
                Debug.Log("Button 2 clicked! Adding steps!");
                // Add functionality for Steps++
                break;
            case 3:
                Debug.Log("Button 3 clicked! Adding armour!");
                // Add functionality for armour++
                break;
            case 4:
                Debug.Log("Button 4 clicked! Adding Speed!");
                // Add functionality for Speed++
                break;
            
            
            
            case 5:
                Debug.Log("Button 1 clicked! Buying random Item!");
                // Add functionality for random 
                break;
            case 6:
                Debug.Log("Button 2 clicked! Buying random Item!");
                // Add functionality for random
                break;
            case 7:
                Debug.Log("Button 3 clicked! Buying random Item!");
                // Add functionality for random
                break;
            
            
            case 8:
                Debug.Log("Button 4 clicked! Exiting to dungeon!");
                // Add functionality for exit screen
                break;
            
            
            default:
                Debug.Log("Unknown button clicked!");
                break;
        }
    }
}
