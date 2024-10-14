using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap collisionTilemap;
    public Tilemap doorTilemap;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Set the player's grids to use this room's grids.
        PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if(player != null)
        {
            player.doorTileMap = doorTilemap;
            player.collisionTileMap = collisionTilemap;
            player.groundTileMap = groundTilemap;
        }
    }
}
