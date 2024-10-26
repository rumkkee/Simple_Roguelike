using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject lastSelectedButton;
    public GameObject mainMenuPanel;

    public void OnContinuePressed()
    {
        LoadGameScene();
    }

    public void OnNewGamePressed()
    {
        // TODO: If a currentRunData exists, wipe the currentData
        LoadGameScene();
    }

    public void OnOptionsPressed()
    {

        lastSelectedButton = MenuManager.instance.eventSystem.currentSelectedGameObject;
        MenuManager.instance.OpenOptionsMenu();
    }

    public void OnExitPressed()
    {
        Application.Quit();
        Debug.Log("You've left the game, and I stay here");
        
    }

    private void LoadGameScene()
    {
        mainMenuPanel.SetActive(false);
        SceneManager.LoadScene(Scenes.instance.gameScene);
    }
}
