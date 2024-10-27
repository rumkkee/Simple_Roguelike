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

}
