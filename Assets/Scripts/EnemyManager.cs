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
    public Dictionary<Vector3Int, int> enemyPositions;
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
        enemyPositions = new();
        DontDestroyOnLoad(gameObject);
    }

    // Add enemy to the dictionary.. 
    public void addEnemyToDict(int ID, EnemyEntity newEnemy)
    {
        enemyDict.Add(ID, newEnemy);
    }

    public void deleteEnemy(int ID, Vector3Int currentPos)
    {
        EnemyEntity retval;
        if (enemyDict.TryGetValue(ID, out retval))
        {

            enemyDict.Remove(ID);
            enemyPositions.Remove(currentPos);
            Destroy(retval.gameObject);
            // De list the key..

        }
        else
        {
            Debug.LogError("Attempting to remove ID that doesn't exist @ 34");
        }
    }

    public IEnumerator doAllEnemyActions(Transform player)
    {
        if (enemyTurn)
        {
            yield break;
        }
        enemyTurn = true;
        foreach (var item in enemyDict)
        {
            yield return StartCoroutine(item.Value.pathfinding.pathfindTo(player));
        }
        yield return new WaitForSeconds(0.05f);
        enemyTurn = false;

        yield break;
    }
    public bool TryMoveEnemy(int enemyID, Vector3Int currentPos, Vector3Int newPos)
    {
        // Check if the new position is already occupied by a different enemy
        if (enemyPositions.TryGetValue(newPos, out int occupyingEnemyID) && occupyingEnemyID != enemyID)
        {
            return false; // Position occupied by another enemy, move fails
        }

        // Update positions: remove old, add new
        enemyPositions.Remove(currentPos);
        enemyPositions[newPos] = enemyID;
        return true;
    }
}
