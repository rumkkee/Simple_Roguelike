using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public EnemyPathfinding pathfinding;
    [HideInInspector]
    public static int totalEnemies = 0;
    [HideInInspector]
    public int enemyID; 
    public EnemyStats enemyStats;
    public int currentHealth;
    private void Start() {
        enemyID = totalEnemies + 1;
        currentHealth = enemyStats.startingHealth;
        totalEnemies++;
        Debug.Log($"enemy ID {enemyID}");
        EnemyManager.instance.addEnemyToDict(enemyID, this);
    }
    public void pathFind(Transform target) {
        Debug.Log($"Pathfinding to transform.Pos{target.position}");
        StartCoroutine(pathfinding.pathfindTo(target));
    }
}
