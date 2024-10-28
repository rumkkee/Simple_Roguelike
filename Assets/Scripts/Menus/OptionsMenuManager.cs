using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class OptionsMenuManager : MonoBehaviour
{
    public GameObject lastSelectedButton;

    public TextMeshProUGUI optionsTitleText;
    public TextMeshProUGUI musicButtonText;
    public TextMeshProUGUI screenModeButtonText;
    public TextMeshProUGUI screenModeText;
    public TextMeshProUGUI languageButtonText;
    public TextMeshProUGUI languageText;
    public TextMeshProUGUI setDefaultText;
    public TextMeshProUGUI exitText;

    private string fullScreenText;
    private string windowedText;

    public Slider musicVolumeSlider;
    public Button musicButton; // Used to return to this button from the volume slider

    public void OnExitPressed()
    {
        lastSelectedButton = EventSystem.current.currentSelectedGameObject;
        this.gameObject.SetActive(false);
        MenuManager.instance.OnOptionsMenuClosed();
    }

    public void OnLanguageButtonPressed()
    {
        LanguageManager.instance.toggleLanguage();
        SetLanguageText();
        MenuManager.instance.SetMenuText();
        //string currentLang = LanguageManager.instance.currentLanguage.ToString();
        //languageText.text = currentLang;
    }

    public void OnScreenModePressed()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
            screenModeText.text = windowedText;
        }
        else
        {
            Screen.fullScreen = true;
            screenModeText.text = fullScreenText;
        }
    }

    public void OnMusicVolumeButtonPressed()
    {
        EventSystem.current.SetSelectedGameObject(musicVolumeSlider.gameObject);
        StartCoroutine(OnSliderBeingControlled());
    }

    public void OnSliderValueChanged()
    {
        AudioManager.instance.SetVolume(musicVolumeSlider.value);
    }

    private IEnumerator OnSliderBeingControlled()
    {
        while(EventSystem.current.currentSelectedGameObject == musicVolumeSlider.gameObject)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                EventSystem.current.SetSelectedGameObject(musicButton.gameObject);
                yield break;
            }
        }
    }

    public void SetText(MenuScripts scripts)
    {
        optionsTitleText.text = scripts.optionsTitle;
        musicButtonText.text = scripts.musicVol;
        screenModeButtonText.text = scripts.screenMode;
        languageButtonText.text = scripts.language;
        setDefaultText.text = scripts.setDefault;
        exitText.text = scripts.exit;

        SetScreenModeText(scripts.fullScreen, scripts.windowed);
        SetLanguageText();
    }

    private void SetScreenModeText(string fullScreen, string windowed)
    {
        fullScreenText = fullScreen;
        windowedText = windowed;
        screenModeText.text = (Screen.fullScreen) ? fullScreenText : windowedText;
    }

    private void SetLanguageText()
    {
        bool isEnglish = LanguageManager.instance.currentLanguage == Language.English;
        languageText.text = (isEnglish) ? "English" : "Espanol";

    }


}
