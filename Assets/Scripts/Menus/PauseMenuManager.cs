using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        PlayerManager.instance.gameObject.SetActive(true);
    }

    public void OnSavePressed()
    {

    }

    public void OnSettingsPressed()
    {
        MenuManager.instance.OpenOptionsMenu();
    }

    public void OnExitToMainPressed()
    {
        pauseMenuPanel.SetActive(false);
        PlayerManager.instance.gameObject.SetActive(true);

        MenuManager.instance.mainMenuManager.mainMenuPanel.SetActive(true);
        SceneManager.LoadScene(Scenes.instance.mainMenuScene);
    }

    public bool isGamePaused() => pauseMenuPanel.activeInHierarchy;

}
