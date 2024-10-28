using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager instance;

    public GameObject pauseMenuPanel;
    public GameObject lastSelectedButton;

    public GameObject gameSavedPanel;

    public TextMeshProUGUI pausedText;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI saveText;
    public TextMeshProUGUI savedNotificationText;
    public TextMeshProUGUI optionsText;
    public TextMeshProUGUI exitText;

    private IEnumerator gameSavedTextCoroutine;

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
        lastSelectedButton = EventSystem.current.currentSelectedGameObject;
        pauseMenuPanel.SetActive(false);
        PlayerManager.instance.gameObject.SetActive(true);
    }

    public void OnShopPressed()
    {
        // Open Shop
        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(Scenes.instance.shopScene);
    }

    public void OnSavePressed()
    {
        // Call the SaveManager to Save your game
        SaveManger.instance.setSave(SaveManger.saveFileOne, PlayerManager.instance.statsMan.stats);
        Debug.Log("Game Saved");
        Debug.Log(SaveManger.instance.fetchSave(SaveManger.saveFileOne));
        Debug.Log(SaveManger.instance.fetchSave("Eos"));

        // Display game saved text

        //StartCoroutine(GameSavedTextDisplay());
        if (gameSavedTextCoroutine != null)
        {
            StopCoroutine(gameSavedTextCoroutine);
        }

        gameSavedTextCoroutine = GameSavedTextDisplay();
        StartCoroutine(gameSavedTextCoroutine);
    }

    private IEnumerator GameSavedTextDisplay()
    {
        gameSavedPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        gameSavedPanel.SetActive(false);
        gameSavedTextCoroutine = null;
    }

    public void OnSettingsPressed()
    {
        lastSelectedButton = EventSystem.current.currentSelectedGameObject;
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


    public void SetText(MenuScripts script)
    {
        pausedText.text = script.pauseMenuTitle;
        continueText.text = script.continueText;
        saveText.text = script.save;
        savedNotificationText.text = script.gameSavedNotifier;
        optionsText.text = script.options;
        exitText.text = script.exit;
    }
}
