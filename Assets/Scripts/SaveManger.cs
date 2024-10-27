using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SaveManger : MonoBehaviour
{
    public static SaveManger instance;

    public static string saveFileOne = "SaveFileOne";

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

    public void setSave(String saveFileName, PlayerStats stats) {
        string retval = stats.Serialize();
        string hash = generateHash(retval);
        string saveFileNameHash = saveFileName + "_Hash";
        PlayerPrefs.SetString(saveFileName, retval);
        PlayerPrefs.SetString(saveFileNameHash, hash);
        
    }
    public string generateHash(string concatenatedData) {
        byte[] dataBytes = Encoding.UTF8.GetBytes(concatenatedData);

        using SHA256 sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(dataBytes);

        StringBuilder hashString = new StringBuilder();
        foreach (var b in hashBytes)
        {
            hashString.Append(b.ToString("x2"));
        }

        return hashString.ToString();
    }
    public string fetchSave(String saveFileName) {
        string saveFileNameHash = saveFileName + "_Hash";
        string data = PlayerPrefs.GetString(saveFileName);
        string hash = PlayerPrefs.GetString(saveFileNameHash);
        string hash2 = generateHash(data);
        if(hash == hash2) {
            return data;
        }
        Debug.LogError("Lol he cheated! what a fucking loser.");
        // Nice try jack ass no save data for you.. 
        return "";
    }
}
