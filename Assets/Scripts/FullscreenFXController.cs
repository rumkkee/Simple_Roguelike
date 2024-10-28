using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FullscreenFXController : MonoBehaviour
{
    [Header("Refrences")]
    [HideInInspector]
    public static FullscreenFXController instance;
    public Material dmg_material;
    public ScriptableRendererFeature dmg_feature;
    public Material time_material;
    public ScriptableRendererFeature time_feature;
    public float timeShaderDuration = 0.25f;
    public float timeShaderFadeTime = 0.5f;
    public float damageShaderFadein = 0.50f;
    public float damageShaderDuration = 1.25f;
    public float damageShaderFadeOut = 0.50f;
    private int _uVorInten = Shader.PropertyToID("uVorIntense");
    private int _uVinIntensity = Shader.PropertyToID("uVinIntensity");
    private int _uFadeVal = Shader.PropertyToID("FadeVal");

    private const float VOR_INTENSITY_START = 1.25f;
    private const float VI_INTENSITY_START = 1.25f;

    public void Awake()
    {
        // check for any other inst. 
        if (instance != null && instance != this)
        {
            // Destroy(gameObject);
            return;
        }
        // Okay then init
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator Hurt()
    {
        dmg_feature.SetActive(true);
        dmg_material.SetFloat(_uVorInten, 0f);
        dmg_material.SetFloat(_uVinIntensity, 0f);
        float elapsedTime = 0f;
        while (elapsedTime < damageShaderFadein)
        {
            elapsedTime += Time.deltaTime;

            float lerpVor = Mathf.Lerp(0f, VOR_INTENSITY_START, elapsedTime / damageShaderFadeOut);
            float lerpVignette = Mathf.Lerp(0f, VI_INTENSITY_START, elapsedTime / damageShaderFadeOut);
            dmg_material.SetFloat(_uVorInten, lerpVor);
            dmg_material.SetFloat(_uVinIntensity, lerpVignette);
            yield return null;
        }

        dmg_material.SetFloat(_uVorInten, VOR_INTENSITY_START);
        dmg_material.SetFloat(_uVinIntensity, VI_INTENSITY_START);

        yield return new WaitForSeconds(damageShaderDuration);

        elapsedTime = 0f;
        while (elapsedTime < damageShaderFadeOut)
        {
            elapsedTime += Time.deltaTime;

            float lerpVor = Mathf.Lerp(VOR_INTENSITY_START, 0f, elapsedTime / damageShaderFadeOut);
            float lerpVignette = Mathf.Lerp(VI_INTENSITY_START, 0f, elapsedTime / damageShaderFadeOut);
            dmg_material.SetFloat(_uVorInten, lerpVor);
            dmg_material.SetFloat(_uVinIntensity, lerpVignette);
            yield return null;
        }

        dmg_feature.SetActive(false);

    }

    public IEnumerator TimeFX()
    {
        time_feature.SetActive(true);
        time_material.SetFloat(_uFadeVal, 1f);
        float elapsedTime = 0f;
        while (elapsedTime < timeShaderFadeTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpFade = Mathf.Lerp(1f, 0.75f, elapsedTime / timeShaderFadeTime);
            time_material.SetFloat(_uFadeVal, lerpFade);
            yield return null;
        }
        time_material.SetFloat(_uFadeVal, 0.75f);
        yield return new WaitForSeconds(timeShaderDuration);

        elapsedTime = 0f;
        while (elapsedTime < timeShaderFadeTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpFade = Mathf.Lerp(0.75f, 1f, elapsedTime / timeShaderFadeTime);
            time_material.SetFloat(_uFadeVal, lerpFade);
            yield return null;
        }

        time_feature.SetActive(false);
    }
}
