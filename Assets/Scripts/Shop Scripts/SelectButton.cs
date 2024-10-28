using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButton : MonoBehaviour
{

    public GameObject FirstButton;

    void Start()
    {
        //Debug.Log("button clicked!");
        EventSystem.current.SetSelectedGameObject(FirstButton);
    }

}
