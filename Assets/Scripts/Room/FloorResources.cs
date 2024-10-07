using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FloorResources : MonoBehaviour
{
    // TODO: Add starting room prefab,

    // TODO: Add list for enemy rooms
    // TODO: Add list for puzzle rooms
    // TODO: Add Shop Room, treasure room, boss room
    public Room startingRoomPrefab;
    public List<Room> enemyRooms;
    public List<Room> idleRooms;
    public List<Room> puzzleRooms;
    public Room shopRoom;

    public Vector2 roomScale;
    public Vector2 GetRoomScale()
    {
        return roomScale;
    }
}
