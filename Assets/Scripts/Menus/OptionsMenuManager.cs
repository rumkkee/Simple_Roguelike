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
    public TextMeshProUGUI languageText;
    public TextMeshProUGUI screenModeText;

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
        string currentLang = LanguageManager.instance.currentLanguage.ToString();
        languageText.text = currentLang;
    }

    public void OnScreenModePressed()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
            screenModeText.text = "Windowed";
        }
        else
        {
            Screen.fullScreen = true;
            screenModeText.text = "Full Screen";
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
        while (EventSystem.current.currentSelectedGameObject == musicVolumeSlider.gameObject)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                EventSystem.current.SetSelectedGameObject(musicButton.gameObject);
                yield break;
            }
        }
    }
}
