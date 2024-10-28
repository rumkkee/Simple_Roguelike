using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/*
 *This script is used to transition to a shop, either by NPC interaction or by story event 
 */


public class BackToDungeon : MonoBehaviour
{

    public string shopSceneName = "Dungeon";
    public float delayBeforeTrans = 1f; //time in seconds before trans
                                        // Start is called before the first frame update

    public void GoToDungeon()
    {
        Debug.Log("Exiting Shop");
        StartCoroutine(transitionToDungeon());
    }

    IEnumerator transitionToDungeon()
    {
        yield return new WaitForSeconds(delayBeforeTrans);
        SceneManager.LoadScene(shopSceneName);
    }

}
