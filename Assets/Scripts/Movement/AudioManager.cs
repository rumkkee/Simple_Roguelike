using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float currentMusicVolume;

    public void SetVolume(float volume)
    {
        currentMusicVolume = volume;
    }
}
