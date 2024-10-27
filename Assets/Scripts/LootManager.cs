using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LootManager : MonoBehaviour
{
    [HideInInspector]
    public static LootManager instance;
    public GameObject[] items;
    public Collectable[] collectable;

    public void Awake()
    {
        // check for any other inst. 
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // Okay then init
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private int _getCollectable()
    {
        int random = Random.Range(1, 101);
        List<int> possibleItems = new();
        for (int i = 0; i < items.Length; i++)
        {
            if (random <= collectable[i].stats.dropChance)
            {
                possibleItems.Add(i);
            }
        }
        if (possibleItems.Count > 0)
        {
            return possibleItems[Random.Range(0, possibleItems.Count)];
        }
        return -1;
    }

    public void InstantiateLoot(Vector3 spawnPos)
    {
        int itemIndex = _getCollectable();

        if (itemIndex == -1)
        {
            return;
        }

        GameObject game = Instantiate(items[itemIndex], spawnPos, Quaternion.identity);

        Rigidbody2D rb = game.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float dropForce = Random.Range(100, 201); // Adjusted range to make it more visible
            Vector2 dropDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rb.AddForce(dropDir * dropForce, ForceMode2D.Impulse);

            Debug.Log($"Applied force of {dropForce} in direction {dropDir} to item {game.name}");
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on instantiated item.");
        }
    }
}