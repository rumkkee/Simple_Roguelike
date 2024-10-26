using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public float musicVol;
    public Language language;


    public void SetDefault()
    {
        musicVol = 1;
        language = Language.English;
    }

}
