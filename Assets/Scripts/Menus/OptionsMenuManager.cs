using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsMenuManager : MonoBehaviour
{
    public GameObject lastSelectedButton;
    public TextMeshProUGUI languageText;

    public void OnExitPressed()
    {
        lastSelectedButton = MenuManager.instance.eventSystem.currentSelectedGameObject;
        this.gameObject.SetActive(false);
        MenuManager.instance.OpenMainMenu();
    }

    public void OnLanguageButtonPressed()
    {
        LanguageManager.instance.toggleLanguage();
        string currentLang = LanguageManager.instance.currentLanguage.ToString();
        languageText.text = currentLang;
    }
}
