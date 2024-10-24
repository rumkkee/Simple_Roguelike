using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

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
        // TODO: Implement OnOptions

        // 11:53pm

    }

    public void OnExitPressed()
    {
        Application.Quit();
        Debug.Log("You've left the game, and I stay here");
        
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(Scenes.instance.gameScene.name);
    }
}
