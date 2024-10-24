using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // TAKKKYOOONNN
    // https://youtu.be/yO3VWqbe8Lc?si=Bv_lNIgKgM9ThvRv
    [HideInInspector]
    public static EnemyManager instance;
    [HideInInspector]
    public Dictionary<int, EnemyEntity> enemyDict;
    public bool enemyTurn;
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
        enemyDict = new();
        DontDestroyOnLoad(gameObject);
    }

    // Add enemy to the dictionary.. 
    public void addEnemyToDict(int ID, EnemyEntity newEnemy)
    {
        enemyDict.Add(ID, newEnemy);
    }

    public void deleteEnemy(int ID)
    {
        EnemyEntity retval;
        if (enemyDict.TryGetValue(ID, out retval))
        {
            Destroy(retval.gameObject);
            // De list the key..
            enemyDict.Remove(ID);
        }
        else
        {
            Debug.LogError("Attempting to remove ID that doesn't exist @ 34");
        }
    }

    public IEnumerator doAllEnemyActions(Transform player)
    {
        enemyTurn = true;
        foreach (var item in enemyDict)
        {
            yield return StartCoroutine(item.Value.pathfinding.pathfindTo(player));
        }
        yield return new WaitForSeconds(0.25f);
        enemyTurn = false;

        yield break;
    }
}
