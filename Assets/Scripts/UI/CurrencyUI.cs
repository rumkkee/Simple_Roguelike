using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    public void updateCurrencyDisplayed(int currency)
    {
        currencyText.text = currency.ToString();
    }
}
