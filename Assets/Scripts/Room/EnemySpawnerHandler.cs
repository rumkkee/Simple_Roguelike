using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnerHandler : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyList;

    public void spawnAllEnemies(Tilemap ground, Tilemap wall)
    {
        int len = 1;
        
        if(PlayerManager.instance.statsMan.stats.startingHealth >= 10) {
            len++;
        }
        if(PlayerManager.instance.statsMan.stats.startingHealth >= 15) {
            len++;
        }
        foreach (var point in spawnPoints)
        {
            int randIndex = Random.Range(0, len);
            GameObject enemy = Instantiate(enemyList[randIndex], point.position, Quaternion.identity);
            EnemyPathfinding pwd = enemy.GetComponent<EnemyPathfinding>();
            pwd.groundTiles = ground;
            pwd.wallTiles = wall;
        }
    }
}
