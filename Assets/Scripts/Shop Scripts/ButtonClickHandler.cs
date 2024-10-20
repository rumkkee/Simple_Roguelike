using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    /*
    While there are four items, heart, damage, armor, speed.
    We only show 3 random items in the shop.
    Hence randomItems One through Three.
    */
    private int randomItemOne = 1;
    private int randomItemTwo = 2;
    private int randomItemThree = 3;

    //Health, Attack, Armor, Speed
    private List<int> randItems;
    //0-5
    private List<int> randTiers;
    //Dictionary resultItem[key] = value ... This will ultimately result in giving us the item we want to obtain.
    Dictionary<string, ScriptableObject> resultItem;

    //Tier Items:=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=-
    HealthItem heartTier1;
    HealthItem heartTier2;
    HealthItem heartTier3;
    HealthItem heartTier4;
    HealthItem heartTier5;
    //=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-
    DamageItem damageTier1;
    DamageItem damageTier2;
    DamageItem damageTier3;
    DamageItem damageTier4;
    DamageItem damageTier5;
    //=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-
    ArmorItem armorTier1;
    ArmorItem armorTier2;
    ArmorItem armorTier3;
    ArmorItem armorTier4;
    ArmorItem armorTier5;
    //=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-
    SpeedItem speedTier1;
    SpeedItem speedTier2;
    SpeedItem speedTier3;
    SpeedItem speedTier4;
    SpeedItem speedTier5;
    //END OF ITEM TIERS=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-
    //Initialize the dictionary with all keys and values

    public enum ButtonType
    {
        BuyHealth,
        BuySteps,
        BuyArmour,
        BuySpeed,
        ExitShop,
        BuyRandom1,
        BuyRandom2,
        BuyRandom3,
        SpeakMerchant
    }

    //https://docs.unity3d.com/530/Documentation/ScriptReference/MonoBehaviour.OnLevelWasLoaded.html
    //Generate Random Items as soon as scene loads
    /*
    This Awake function will generate 3 random numbers to decide what Items we want to use in the shop.
    We random 1-4 inclusive.
    1 = Health,
    2 = Attack,
    3 = Defensive,
    4 = Speed
    */
    void Awake () {
        resultItem = new Dictionary<string, ScriptableObject>
        {
            {"1,1", heartTier1}, {"1,2", heartTier2}, {"1,3", heartTier3}, {"1,4", heartTier4}, {"1,5", heartTier5},
            {"2,1", damageTier1}, {"2,2", damageTier2}, {"2,3", damageTier3}, {"2,4", damageTier4}, {"2,5", damageTier5},
            {"3,1", armorTier1}, {"3,2", armorTier2}, {"3,3", armorTier3}, {"3,4", armorTier4}, {"3,5", armorTier5},
            {"4,1", speedTier1}, {"4,2", speedTier2}, {"4,3", speedTier3}, {"4,4", speedTier4}, {"4,5", armorTier5}
            
        };

        //Generate Random Items:
        randItems = new List<int>{1, 2, 3, 4}; //All randomly selected items are in this list.
        // List<int> numbers = new List<int> {1, 2, 3, 4}; // Initialize random numbers

        // Randomly shuffle the list
        System.Random rng = new System.Random();
        int n = randItems.Count;
        
        // Fisher-Yates shuffle algorithm
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = randItems[k];
            randItems[k] = randItems[n];
            randItems[n] = value;
        }

        // Assign the randomized items to your variables
        randomItemOne = randItems[0];
        randomItemTwo = randItems[1];
        randomItemThree = randItems[2];

        // randItems.Sort(); //Sort the items in the List to be used in randomized Item Places.
        //=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-
        //-------------------------------------------------------------------------------------------
        //=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-
        //Generate Random Tiers:
        List<int> randTiersNumbers = new List<int> {1, 2, 3, 4, 5}; //Initialize random numbers

        //Randomly shuffle the list
        int m = randTiersNumbers.Count;

        // Fisher-Yates shuffle algorithm
        while (m > 1)
        {
            m--;
            int k = rng.Next(m + 1);
            int value = randTiersNumbers[k];
            randTiersNumbers[k] = randTiersNumbers[m];
            randTiersNumbers[m] = value;
        }

        //Tiers are now randomized:
        List<int> randomTiers = randTiersNumbers;
        //=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-
        //-------------------------------------------------------------------------------------------
        //=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-=-=-=-=--=-=-
        //Now lets create a List that contains both values from:
        // randItems [1,2,3,4] and randomTiers[#, #, #] (Any num)
        

    }
    
    // Method that accepts a parameter to handle different button clicks
    public void OnButtonClick(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                Debug.Log("Button 0 clicked! Speaking to merchant!");
                // Add functionality for Merchant
                break;
            
            case 1:
                Debug.Log("Button 1 clicked! Adding health");
                // Add functionality for Health++
                break;
            case 2:
                Debug.Log("Button 2 clicked! Adding steps!");
                // Add functionality for Steps++
                break;
            case 3:
                Debug.Log("Button 3 clicked! Adding armour!");
                // Add functionality for armour++
                break;
            case 4:
                Debug.Log("Button 4 clicked! Adding Speed!");
                // Add functionality for Speed++
                break;
            
            //These Cases Are for a Random Item (Generated in Awake()):
            case 5:
                Debug.Log("Button 5 clicked! Buying random Item! ALSO THIS IS THE RANDOM ITEM: " + randItems[0]);
                //Get Item for Shop
                ScriptableObject gottenItemOne = getItemOneTier();
                Debug.Log("This is the item I got as result of getItemOneTier(): " + gottenItemOne); //Not sure how to check of random item gotten works.
                // Check for money if can afford random item

                //If I can afford this purchase:

                //Else Dialogue, cannot afford or whatever we want to say.
                break;

            case 6:
                Debug.Log("Button 5 clicked! Buying random Item! ALSO THIS IS THE RANDOM ITEM: " + randItems[1]);
                //Get Item for Shop
                ScriptableObject gottenItemTwo = getItemTwoTier();
                Debug.Log("This is the item I got as result of getItemTwoTier(): " + gottenItemTwo);

                // Check for money if can afford random item

                //If I can afford this purchase:

                //Else Dialogue, cannot afford or whatever we want to say.
                break;

            case 7:
                Debug.Log("Button 5 clicked! Buying random Item! ALSO THIS IS THE RANDOM ITEM: " + randItems[2]);
                //Get Item for Shop
                ScriptableObject gottenItemThree = getItemThreeTier();
                Debug.Log("This is the item I got as result of getItemThreeTier(): " + gottenItemThree);
                // Check for money if can afford random item

                //If I can afford this purchase:

                //Else Dialogue, cannot afford or whatever we want to say.
                break;
    
            case 8:
                Debug.Log("Button 8 clicked! Exiting to dungeon!");
                // Add functionality for exit screen
                break;
            
            
            default:
                Debug.Log("Unknown button clicked!");
                break;
        }
    }

    public ScriptableObject getItemOneTier() {
        int itemOne = randItems[0]; //1-4 Possible
        int tierOne = randTiers[0]; //1-5 Possible

        string itemKey = itemOne + "," + tierOne;

        //Call the dictionary with itemKey and return the value.

        // Return or manipulate the itemOne value as needed
        return resultItem[itemKey];
    }

    public ScriptableObject getItemTwoTier() {
        int itemTwo = randItems[1];
        int tierTwo = randTiers[1];

        string itemKey = itemTwo + "," + tierTwo;
        return resultItem[itemKey];
    }

    public ScriptableObject getItemThreeTier() {
        int itemThree = randItems[2];
        int tierThree = randTiers[2];

        string itemKey = itemThree + "," + tierThree;
        return resultItem[itemKey];
    }
}
