using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [Header("visual que:")]
    [SerializeField] private GameObject visualCue;

    public string characterName; // Name of the character whose dialogue will be triggered
    private bool playerInRange;
    private static bool isActive = DialogueManager.dialogueActive;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log(characterName + " entered");
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            Debug.Log(characterName + " exited");
        }
    }


    private void Update()
    {
        if (playerInRange && !DialogueManager.dialogueActive)
        {
            visualCue.SetActive(true);


            if (Input.GetKeyUp(KeyCode.E) && !DialogueManager.dialogueActive) // change later if the interact key changes 
            {
                // Trigger the dialogue for this NPC via the DialogueManager
                DialogueManager.instance.startDialogue(characterName);
            }

        }
        else
        {
            visualCue.SetActive(false);
        }
    }
}
