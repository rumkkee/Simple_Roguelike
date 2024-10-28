using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public MainMenuManager mainMenuManager;
    public OptionsMenuManager optionsMenuManager;
    public PauseMenuManager pauseMenuManager;

    public MenuScripts englishScripts;
    public MenuScripts spanishScripts;
    public MenuScripts currentScripts; // Set to english or spanish scripts, dependent on which are active

    public EventSystem eventSystem;

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

        currentScripts = spanishScripts;
        //currentScripts = (LanguageManager.instance.currentLanguage == Language.English) ? englishScripts : spanishScripts;
    }

    private void Start()
    {
        mainMenuManager.SetText(currentScripts);
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

    public void OnOptionsMenuClosed()
    {
        if(SceneManager.GetActiveScene().name == Scenes.instance.gameScene)
        {
            OpenPauseMenu();
        }
        else
        {
            OpenMainMenu();
        }
    }

}
