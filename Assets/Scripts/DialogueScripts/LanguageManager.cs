using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager instance;
    public Language currentLanguage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //this will be a global script that persists between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void toggleLanguage()
    {
        if (currentLanguage == Language.English)
        {
            currentLanguage = Language.Spanish;
        }
        else
        {
            currentLanguage = Language.English;
        }
        if (DialogueManager.instance != null) { 
            DialogueManager.instance.setLanguage(currentLanguage);
        }
    }
}
