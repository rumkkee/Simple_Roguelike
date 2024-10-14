using UnityEngine;


[CreateAssetMenu(fileName = "HourglassItemScriptableObject", menuName = "ScriptableObjects/HourglassItem")]
public class HourglassItem : ScriptableObject
{
    /**
    * The hourglass item will increase the number of steps
    * a player is allowed to make throughout the dungeon.
    **/
    public int steps = 1;
}