using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WASDNav : MonoBehaviour
{

    public Button[] buttons;
    private int selectedIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectButton();
    }

    // Update is called once per frame
    void Update()
    {
        // Navigate through buttons using WASD
        if (Input.GetKeyDown(KeyCode.W)) // Move up
        {
            selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : buttons.Length - 1;
            selectButton();
        }
        else if (Input.GetKeyDown(KeyCode.S)) // Move down
        {
            selectedIndex = (selectedIndex < buttons.Length - 1) ? selectedIndex + 1 : 0;
            selectButton();
        }

        // Press the currently selected button with Space or Enter
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            buttons[selectedIndex].onClick.Invoke();
        }
    }

    void selectButton()
    {
        buttons[selectedIndex].Select();
    }
}
