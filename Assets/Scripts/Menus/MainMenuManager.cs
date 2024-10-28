using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject lastSelectedButton;
    public GameObject mainMenuPanel;

    public Button continueButton; // Will be selected first if a saved game exists. Else, is made unselectable.
    public TextMeshProUGUI continueButtonText; // will be greyed if disabled
    public Button newGameButton; // Will be selected first if no saved game exists

    public TextMeshProUGUI gameTitleText;
    public TextMeshProUGUI newGameText;
    public TextMeshProUGUI optionsText;
    public TextMeshProUGUI exitText;

    public void Start()
    {
        OnSceneLoaded();
    }

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

        lastSelectedButton = EventSystem.current.currentSelectedGameObject;
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


    public void OnSceneLoaded()
    {
        string savedFile = SaveManger.instance.fetchSave(SaveManger.saveFileOne);
        bool savedDataExists = (savedFile != "") ? true : false;
        //Debug.Log(savedFile);

        if (savedDataExists)
        {
            continueButton.interactable = true;
            continueButtonText.color = Color.white;
            EventSystem.current.SetSelectedGameObject(continueButton.gameObject);

        }
        else
        {
            continueButton.interactable = false;
            continueButtonText.color = Color.gray;
            EventSystem.current.SetSelectedGameObject(newGameButton.gameObject);
        }
    }

    public void SetText(MenuScripts menuScript)
    {
        gameTitleText.text = menuScript.gameTitle;
        continueButtonText.text = menuScript.continueText;
        newGameText.text = menuScript.newGame;
        optionsText.text = menuScript.options;
        exitText.text = menuScript.exit;
    }
}
