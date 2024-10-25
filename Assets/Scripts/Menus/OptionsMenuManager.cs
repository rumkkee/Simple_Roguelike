using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public GameObject lastSelectedButton;

    public void OnExitPressed()
    {
        lastSelectedButton = MenuManager.instance.eventSystem.currentSelectedGameObject;
        this.gameObject.SetActive(false);
        MenuManager.instance.OpenMainMenu();
    }
}
