using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class StepCounterUI : MonoBehaviour
{
    public delegate void StepCountUpdated();
    public static event StepCountUpdated StepCountUpdate;

    public TextMeshProUGUI stepsRemainingText;

    public void Awake()
    {
        PlayerStats.StepsRemainingUpdated += updateStepsDisplayed;
    }

    public void updateStepsDisplayed(int stepsRemaining)
    {
        stepsRemainingText.text = stepsRemaining.ToString();
    }
   
}
