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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Set the player's grids to use this room's grids.
        PlayerManager player = collider.GetComponent<PlayerManager>();
        if(player == null) return;
        player.Movement.activeRoom = this;
        // Set the camera's Confiners to this.. 
        Debug.Log(player.Camera);
        player.Camera.setConfines(cameraConfines, groundTilemap.transform);

    }
}
