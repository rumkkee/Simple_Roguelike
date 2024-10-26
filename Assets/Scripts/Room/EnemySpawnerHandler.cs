using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnerHandler : MonoBehaviour
{
    public Transform[] spawnPoints; 
    public GameObject[] enemyList; 

    public void spawnAllEnemies(Tilemap ground, Tilemap wall) {
        foreach (var point in spawnPoints) 
        {
            int randIndex = Random.Range(0, enemyList.Length);
            GameObject enemy = Instantiate(enemyList[randIndex], point.position, Quaternion.identity);
            EnemyPathfinding pwd = enemy.GetComponent<EnemyPathfinding>();
            pwd.groundTiles = ground;
            pwd.wallTiles = wall;
        }
    }
}
