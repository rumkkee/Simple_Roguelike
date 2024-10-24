using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public MainMenuManager mainMenuManager;
    public OptionsMenuManager optionsMenuManager;
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


    }

    public void OpenOptionsMenu()
    {
        optionsMenuManager.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(optionsMenuManager.lastSelectedButton);
    }
}
