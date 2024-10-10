using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FloorResources : MonoBehaviour
{
    public Room startingRoomPrefab;
    public Room exitRoom; // This will be the boss room or exit room depending on what floor this is
    public List<Room> dungeonRooms;
    public List<Room> idleRooms;
    public List<Room> puzzleRooms;
    public Room shopRoom;
    public Room treasureRoom;

    public Vector2 roomScale;
    public Vector2 GetRoomScale()
    {
        return roomScale;
    }

    public Room GetExitRoom()
    {
        // TODO: If this is the last floor of the game, return the boss room. Else, return 
        return exitRoom;
    }

    public Room GetRoom(RoomNode roomNode)
    {
        if(roomNode.roomType == RoomType.bossRoom || roomNode.roomType == RoomType.nextFloorRoom)
        {
            return exitRoom;
        }
        else if(roomNode.roomType == RoomType.puzzleRoom)
        {
            int size = puzzleRooms.Count;
            int randomIndex = Random.Range(0, size - 1);
            Room randomPuzzleRoom = puzzleRooms[randomIndex];
            return randomPuzzleRoom;
        }
        else if(roomNode.roomType == RoomType.treasureRoom){
            return treasureRoom;
        }
        else if(roomNode.roomType == RoomType.firstRoom)
        {
            return startingRoomPrefab;
        }
        else
        {
            int size = dungeonRooms.Count;
            int randomIndex = Random.Range(0, size - 1);
            Room randomDungeonRoom = dungeonRooms[randomIndex];
            return randomDungeonRoom;
        }
        // If a room isn't special pick between the dungeon, puzzle, and idle rooms.
    }
}
