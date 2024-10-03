using UnityEngine;


[CreateAssetMenu(fileName = "SpiniaStatsScriptableObject", menuName = "ScriptableObjects/SpiniaStats")]
public class SpiniaStats : ScriptableObject
{
    /**
    * Spinia: https://www.mariowiki.com/Paper_Mario:_The_Thousand-Year_Door_bestiary
    * 
    * These below are the original values:
    * =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    * public int health = 3;
    * public int attack = 1;
    * public int defense = 0;
    * =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    * I leave the comment above here because prototyping with scriptable objects will allow 
    * permanent change when adjusting numbers
    * during run testing.
    **/
    
    public int health = 3;
    public int attack = 1;
    public int defense = 0;
}