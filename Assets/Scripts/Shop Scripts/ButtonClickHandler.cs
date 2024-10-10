using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    // Method that accepts a parameter to handle different button clicks
    public void OnButtonClick(int buttonID)
    {
        switch (buttonID)
        {
            case 1:
                Debug.Log("Button 1 clicked! Performing action for Button 1.");
                // Add functionality for Button 1
                break;
            case 2:
                Debug.Log("Button 2 clicked! Performing action for Button 2.");
                // Add functionality for Button 2
                break;
            case 3:
                Debug.Log("Button 3 clicked! Performing action for Button 3.");
                // Add functionality for Button 3
                break;
            case 4:
                Debug.Log("Button 4 clicked! Performing action for Button 3.");
                // Add functionality for Button 3
                break;
            default:
                Debug.Log("Unknown button clicked!");
                break;
        }
    }
}
