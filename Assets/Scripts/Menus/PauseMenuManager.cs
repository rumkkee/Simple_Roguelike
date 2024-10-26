using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager instance;

    public GameObject pauseMenuPanel;
    public GameObject lastSelectedButton;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void OnContinuePressed()
    {
        // Call the game time to resume, if paused
        pauseMenuPanel.SetActive(false);
    }

    public void OnSavePressed()
    {

    }

    public void OnSettingsPressed()
    {

    }

    public void OnExitToMainPressed()
    {
        pauseMenuPanel.SetActive(false);
        MenuManager.instance.mainMenuManager.mainMenuPanel.SetActive(true);
        SceneManager.LoadScene(Scenes.instance.mainMenuScene);
    }

    public bool isGamePaused() => pauseMenuPanel.activeInHierarchy;

}
