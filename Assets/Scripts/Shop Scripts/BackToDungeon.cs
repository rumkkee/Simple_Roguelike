using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/*
 *This script is used to transition to a shop, either by NPC interaction or by story event 
 */


public class TransitionToShop : MonoBehaviour
{

    public string shopSceneName = "Shop Scene";
    public float delayBeforeTrans = 1f; //time in seconds before trans
    // Start is called before the first frame update
    
    public void GoToShop()
    {
        StartCoroutine(transitionToShop());
    }


    IEnumerator transitionToShop()
    {
        yield return new WaitForSeconds(delayBeforeTrans);
        SceneManager.LoadScene(shopSceneName);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("entering shop");
            GoToShop(); 
        }
    }
    
    
}
