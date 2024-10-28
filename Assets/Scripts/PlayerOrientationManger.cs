using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOrientationManger : MonoBehaviour
{
    public GameObject leftSprite;
    public GameObject rightSprite;
    public GameObject leftDust;
    public GameObject rightDust;
    public bool isLeft = false;
    
    public void swtichOrientation(Vector2 dir)
    {
        if (dir == Vector2.left)
        {
            rightSprite.SetActive(true);
            leftSprite.SetActive(false);
            isLeft = false;
        }
        else if (dir == Vector2.right)
        {
            leftSprite.SetActive(true);
            rightSprite.SetActive(false);
            isLeft = true;
        }
    }

    public void setPlayerInvis() {
        leftSprite.SetActive(false);
        rightSprite.SetActive(false);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        // Check the name of the loaded scene
        if (scene.name == Scenes.instance.gameScene)
        {
            leftSprite.SetActive(true);
        }
    }
}
