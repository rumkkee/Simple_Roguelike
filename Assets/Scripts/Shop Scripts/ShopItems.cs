using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    public int itemCost;
    public string itemName;

    public void BuyItem()
    {
        if (PlayerStats.totalCurrency >= itemCost)
        {
            PlayerStats.totalCurrency -= itemCost;
            
            //do later: add item to inventory
            Debug.Log("You bought " + itemName);
        }
        else
        {
            Debug.Log("You don't have enough money");  
        }
    }
    
}
