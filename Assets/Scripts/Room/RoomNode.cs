using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNode
{
    public Vector2 gridPos;
    public RoomType roomType;

    public int distanceFromSpawn; // measured in rooms
    public Dictionary<Vector2, RoomNode> neighborRooms;
    public int neighborCount; // Number of rooms this room is connected to. Helps determine end rooms.
    

    public void AddNeighborNode(Vector2 direction, RoomNode neighborNode)
    {
        if(neighborRooms == null) 
        { 
            neighborRooms = new Dictionary<Vector2, RoomNode>();
        }
        neighborRooms.Add(direction, neighborNode);
        neighborCount++;

    }
}
