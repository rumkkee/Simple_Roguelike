using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class EnemyEntity : MonoBehaviour
{
    public EnemyPathfinding pathfinding;
    [HideInInspector]
    public static int totalEnemies = 0;
    [HideInInspector]
    public int enemyID; 
    public EnemyStats enemyStats;
    public int currentHealth;
    public Image healthBar;
    private Collider2D _collider; 
    private void Start() {
        enemyID = totalEnemies + 1;
        currentHealth = enemyStats.startingHealth;
        totalEnemies++;
        Debug.Log($"enemy ID {enemyID}");
        EnemyManager.instance.addEnemyToDict(enemyID, this);
        _collider = gameObject.GetComponent<Collider2D>();
    }
    public void pathFind(Transform target) {
        Debug.Log($"Pathfinding to transform.Pos{target.position}");
        StartCoroutine(pathfinding.pathfindTo(target));
    }

    public void takeDamage(int amount) {
        currentHealth -= amount;
        currentHealth = math.max(currentHealth, 0);
        updateHealthBar();
        if(currentHealth == 0) {
            int rand = UnityEngine.Random.Range(3,10);
            for (int i = 0; i < rand; i++)
            {
                LootManager.instance.InstantiateLoot(_collider.bounds.center);
            }
            PartcleManager.instance.makePartcleFX(PartcleManager.PartcleType.Blood, _collider.bounds.center);
            EnemyManager.instance.deleteEnemy(enemyID, Vector3Int.CeilToInt(transform.position));
        }
    }

    public void updateHealthBar() {
        healthBar.fillAmount = (float)currentHealth / enemyStats.startingHealth;
    }
}
