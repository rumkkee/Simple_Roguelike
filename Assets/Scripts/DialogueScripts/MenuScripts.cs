using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Menu Script", menuName = "Menu Text Object")]
public class MenuScripts : ScriptableObject
{
    [Header("Main Menu")]
    public string gameTitle;
    public string continueText;
    public string newGame;
    public string options;
    public string exit;

    [Header("Options Menu")]
    public string optionsTitle;
    public string musicVol;
    public string screenMode;
    public string fullScreen;
    public string windowed;
    public string language;
    public string english;
    public string spanish;
    public string setDefault;


    [Header("Pause Menu")]
    public string pauseMenuTitle;
    public string save;
    public string gameSavedNotifier;
    

}
