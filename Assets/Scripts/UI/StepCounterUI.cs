using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class StepCounterUI : MonoBehaviour
{
    public TextMeshProUGUI stepsRemainingText;

    public void updateStepsDisplayed(int stepsRemaining)
    {
        stepsRemainingText.text = stepsRemaining.ToString();
    }

}
