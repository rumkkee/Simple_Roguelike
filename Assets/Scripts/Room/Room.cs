using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    [Header("Tilemap collisions")]
    [Tooltip("The tile map that the ground is on")]
    public Tilemap groundTilemap;
    [Tooltip("The tile map that the collisions are determined is on")]
    public Tilemap collisionTilemap;
    [Tooltip("The tile map that doors will be on")]
    public Tilemap doorTilemap;
    [Tooltip("The polygonCollider which the camera is locked to")]
    public BoxCollider2D cameraConfines;
    public RoomType type = RoomType.firstRoom;
    [Tooltip("The Enemy spawner object")]
    public EnemySpawnerHandler EnemySpawns;
    public bool isEnemyActive = false;
    public bool isRoomCleared = false;

    void Start()
    {
        if (EnemySpawns == null && type == RoomType.dungeonRoom)
        {
            Debug.LogError("No enemy spawner!");
        }
    }

    void Update() {
        if(EnemyManager.instance.enemyDict.Count == 0) {
            isRoomCleared = true;
            EnemyManager.instance.enemyPositions.Clear();
            FloorManager.instance.OpenDoors();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Set the player's grids to use this room's grids.
        PlayerManager player = collider.GetComponent<PlayerManager>();
        TimeManager.instance.clear();
        if (player != null)
        {
            PlayerMovement.activeRoom = this;
            // Set the camera's Confiners to this.. 
            player.Camera.setConfines(cameraConfines, groundTilemap.transform);
            if (type == RoomType.dungeonRoom && !isEnemyActive)
            {
                EnemySpawns.spawnAllEnemies(groundTilemap, collisionTilemap);
            }
            isEnemyActive = true;
            FloorManager.instance.CloseDoors();
            return;
        }
    }
}
