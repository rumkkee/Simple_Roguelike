using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorGenerator : MonoBehaviour
{
    // Have a reference to floor resources, room nodes

    private List<RoomNode> roomNodes;

    [SerializeField] private FloorResources floorResources;
    [SerializeField]private GameObject floorsContainer;

    
    [SerializeField] private int roomCount; // Number of rooms to generate, apart from starting room.

    // Generates the placements for rooms

    // Test Start Script
    private void Start()
    {
        GenerateNodes();
    }
    public void GenerateNodes()
    {
        roomNodes = new List<RoomNode>();

        RoomNode startingNode = new RoomNode();
        startingNode.gridPos = Vector2.zero;

        roomNodes.Add(startingNode);
        Room newRoom = Instantiate(floorResources.startingRoomPrefab, Vector2.zero, Quaternion.identity, floorsContainer.transform);

        int roomsGeneratedCount = 0;

        while (roomsGeneratedCount < roomCount)
        {
            RoomNode nodeSpawnedFrom = roomNodes[Random.Range(0, roomNodes.Count)];

            int randWallPos = Random.Range(0, 4);

            Vector2 gridPosShift = Vector2.zero;
            if (randWallPos == 0) 
            { 
                gridPosShift = Vector2.up; 
            } 
            else if (randWallPos == 1) 
            { 
                gridPosShift = Vector2.right; 
            } 
            else if (randWallPos == 2) 
            { 
                gridPosShift = Vector2.down; 
            } 
            else 
            { 
                gridPosShift = Vector2.left; 
            } 

            Vector2 newNodePos = nodeSpawnedFrom.gridPos + gridPosShift;

            if (NodeExistsAtGridPos(newNodePos))
            {
                continue;
            }

            RoomNode roomNode = new RoomNode();
            roomNode.gridPos = newNodePos;
            roomNodes.Add(roomNode);

            Debug.Log(newNodePos.x + ", " + newNodePos.y);
            newRoom = Instantiate(floorResources.startingRoomPrefab, newNodePos * floorResources.GetRoomScale(), Quaternion.identity, floorsContainer.transform);

            roomsGeneratedCount++;
        }
    }

    private bool NodeExistsAtGridPos(Vector2 gridPos)
    {
        foreach (RoomNode roomNode in roomNodes) 
        { 
            if (roomNode.gridPos == gridPos) 
            {  
                return true; 
            } 
        }
        return false;
    }

    // // Places rooms at each room node
    public void GenerateRooms()
    {

    }

}
