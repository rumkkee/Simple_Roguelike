using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void OnExitPressed()
    {
        Application.Quit();
        Debug.Log("You've left the game, and I stay here");
        
    }
}
