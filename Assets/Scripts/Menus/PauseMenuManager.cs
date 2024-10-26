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

    public GameObject gameSavedPanel;

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

    public void OnSavePressed()
    {
        // Call the SaveManager to Save your game
        SaveManger.instance.setSave(SaveManger.saveFileOne, PlayerManager.instance.stats);
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

}
