using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class StepCounterUI : MonoBehaviour
{
    public delegate void StepCountUpdated();
    public static event StepCountUpdated StepCountUpdate;

    public TextMeshProUGUI stepsRemainingText;

    public void Start()
    {
        PlayerStats.StepsRemainingUpdated += updateStepsDisplayed;

        int remainingSteps = PlayerManager.instance.stats.remainingSteps();
        updateStepsDisplayed(remainingSteps);
    }

    public void updateStepsDisplayed(int stepsRemaining)
    {
        stepsRemainingText.text = stepsRemaining.ToString();
    }

    public void OnDestroy()
    {
        PlayerStats.StepsRemainingUpdated -= updateStepsDisplayed;
    }

}
