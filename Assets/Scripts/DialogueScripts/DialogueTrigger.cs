using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string characterName; // Name of the character whose dialogue will be triggered

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           Debug.Log(characterName + " entered"); 
            // Trigger the dialogue for this NPC via the DialogueManager
            DialogueManager.instance.startDialogue(characterName);
        }
    }
}
