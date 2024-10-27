using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Menu Script", menuName = "Menu Text Object")]
public class MenuScripts : ScriptableObject
{
    public Dictionary<string, string> scripts;
    public string continueText;
    public string newGame;
    public string options;
    public string exit;

}
