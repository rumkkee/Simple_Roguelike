using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;


/*
 * The purpose of this script is to manage all the dialogue and quest objectives over the entire game
 * while taking into account the need to manage other languages.
 * 
 * We employ a singleton pattern for this manager to make sure it is the only one of its kind and make sure it
 * will persist across scenes
 *
 * We can manage translation by using the arrays of ink files corresponding to each language, default is
 * in English, but there is a set language method to change it in the menu with a button. All the appropriate
 * language ink files will be loaded into currentInkFiles for later use. language choice persists between scenes
 *
 * Essentially we can have all the quests and character interactions described in the dictionary questProgress
 * where the <key,value> is the <character name, flag>. The individual NPCs will be named and a trigger script will
 * call the start dialogue method here. It searches currentInkFiles to see if the appropriate character story is
 * in the array, and if it is it begins dialogue with that character. 
 *
 * each npc name should correspond with their ink file for this to work properly
 *
 * expand as needed 
 * 
 */



public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    //place files here 

    [Header("English Ink Files")]
    public TextAsset[] englishInkFiles;
    [Header("Spanish Ink Files")]
    public TextAsset[] spanishInkFiles;
    [Header("Japanese Ink Files")]
    public TextAsset[] japaneseInkFiles;


    private TextAsset[] currentInkFiles; //currently loaded files 

    private string currentLanguage = "english"; //default is English, change later with menu buttons 
    private Language currentLang;

    private Dictionary<string, bool> questProgress; //this is to keep track of which NPCs you have talked to
                                                    //and what story elements you triggered 
                                                    //the string corresponds to the character name OR quest objective
                                                    //more on that later 




    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public static bool dialogueActive { get; private set; } //read only to outside scripts 
    private string currentCharacter;
    private Story story;



    // We will use a singleton pattern to ensure we don't duplicate anything 
    void Awake()
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



    private void Start()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);
        questProgress = new Dictionary<string, bool>();
        setLanguage(currentLanguage); //initialize with default 
        setLanguage(currentLang);
    }



    private void Update()
    {
        if (!dialogueActive) //return right away if not playing 
        {
            return;
        }

        //handle continuation to next line
        if (Input.GetKeyUp(KeyCode.Space)) //this may change depending on input scheme 
        {
            continueDialogue(currentCharacter, story);
        }
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void setLanguage(string language)
    {
        currentLanguage = language;
        if (language == "english")
        {
            currentInkFiles = englishInkFiles;
        }
        else if (language == "spanish")
        {
            currentInkFiles = spanishInkFiles;
        }
        else if (language == "japanese")
        {
            currentInkFiles = japaneseInkFiles;
        }

        Debug.Log("language:" + currentLanguage);

        //display current contents of currentInkFiles
        debugPrintTextAssets();

    }

    public void setLanguage(Language language)
    {
        currentLang = language;
        if (language == Language.English)
        {
            currentInkFiles = englishInkFiles;
        }
        else if (language == Language.Spanish)
        {
            currentInkFiles = spanishInkFiles;
        }
        Debug.Log("language:" + currentLanguage);

        //display current contents of currentInkFiles
        debugPrintTextAssets();
    }

    public void toggleLanguage()
    {
        if (currentLang == Language.English)
        {
            setLanguage(Language.Spanish);
        }
        else
        {
            setLanguage(Language.English);
        }
    }

    public Language getCurrentLanguage() => currentLang;



    public void startDialogue(string characterName)
    {
        currentCharacter = characterName;

        Debug.Log("starting dialogue");

        TextAsset inkFile = getCharacterInkFile(characterName); //get the specific character's story 

        Debug.Log("character chosen: " + characterName);

        if (inkFile != null)
        {
            story = new Story(inkFile.text);
            dialogueActive = true;
            dialoguePanel.SetActive(true);
            continueDialogue(characterName, story);
        }

    }



    //here we will search for this character's story from all the loaded stories 
    private TextAsset getCharacterInkFile(string characterName)
    {
        foreach (var inkFile in currentInkFiles)
        {
            if (inkFile.name == characterName)
            {
                return inkFile;
            }
        }

        return null;
    }



    public void continueDialogue(string characterName, Story story)
    {

        if (story.canContinue)
        {
            string text = story.Continue(); //continue here is like popping the next text off a stack 
            dialogueText.text = text;
            Debug.Log(text); //display dialogue text
            questProgress[characterName] = true; // mark character or quest objective as already visited 
                                                 // comment out this line if you would like to repeat 
                                                 //the same story 

            //note: we may want to edit this whole section to create
            //different options for a default NPC response or something
        }
        else
        {
            exitDialogueMode();
        }

    }



    private void exitDialogueMode()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }



    void debugPrintTextAssets()
    {
        // Loop through the array and print each TextAsset's contents
        foreach (TextAsset textAsset in currentInkFiles)
        {
            if (textAsset != null)
            {
                Debug.Log("currently loaded: " + textAsset.name); //+ ": " + textAsset.text);  // Print name and content of each TextAsset
            }
            else
            {
                Debug.LogWarning("Null TextAsset found in array.");
            }
        }
    }



}
