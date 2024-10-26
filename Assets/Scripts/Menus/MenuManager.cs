using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public MainMenuManager mainMenuManager;
    public OptionsMenuManager optionsMenuManager;
    public PauseMenuManager pauseMenuManager;

    public GameObject currentPausePanel;

    public EventSystem eventSystem;

    public static MenuManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene oldScene, Scene newScene)
    {
        if (newScene.name == Scenes.instance.mainMenuScene.ToString())
        {
            GameObject mainMenuButton = MenuManager.instance.mainMenuManager.lastSelectedButton;
            EventSystem.current.SetSelectedGameObject(mainMenuButton);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!mainMenuManager.mainMenuPanel.activeSelf)
            {
                Debug.Log("Eos");
                OpenPauseMenu();
            }
            Debug.Log("Esset");
            
        }
    }

    public void OpenOptionsMenu()
    {
        optionsMenuManager.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsMenuManager.lastSelectedButton);
    }

    public void OpenMainMenu()
    {
        mainMenuManager.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainMenuManager.lastSelectedButton);
    }

    public void OpenPauseMenu()
    {
        // prevent player from moving
        PlayerManager.instance.gameObject.SetActive(false);

        pauseMenuManager.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(pauseMenuManager.lastSelectedButton);
    }

    public void ClosePauseMenu()
    {
        pauseMenuManager.gameObject.SetActive(false);
    }

    

}
