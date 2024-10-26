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

        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.ToString() == Scenes.instance.mainMenuScene.ToString())
        {

        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
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
        //EventSystem.current.la
    }

    public void OpenPauseMenu()
    {
        pauseMenuManager.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(pauseMenuManager.lastSelectedButton);
    }

    public void UpdateEventSystem()
    {
        eventSystem = EventSystem.current;
    }
}
