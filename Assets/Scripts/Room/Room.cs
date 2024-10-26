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

    void Start()
    {
        if (EnemySpawns == null && type == RoomType.dungeonRoom)
        {
            Debug.LogError("No enemy spawner!");
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Set the player's grids to use this room's grids.
        PlayerManager player = collider.GetComponent<PlayerManager>();
        if (player != null)
        {
            PlayerMovement.activeRoom = this;
            // Set the camera's Confiners to this.. 
            Debug.Log(player.Camera);
            player.Camera.setConfines(cameraConfines, groundTilemap.transform);
            if (type == RoomType.dungeonRoom)
            {
                EnemySpawns.spawnAllEnemies(groundTilemap, collisionTilemap);
            }
            return;
        }
    }
}
