using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    [Header("Tilemap collisions")]
    [SerializeField]
    [Tooltip("The tile map that the ground is on")]
    public Tilemap groundTilemap;
    [SerializeField]
    [Tooltip("The tile map that the collisions are determined is on")]
    public Tilemap collisionTilemap;
    [SerializeField]
    [Tooltip("The tile map that doors will be on")]
    public Tilemap doorTilemap;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Set the player's grids to use this room's grids.
        PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if(player != null)
        {
            player.activeRoom = this;
        }
    }
}
