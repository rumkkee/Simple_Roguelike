using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorGenerator : MonoBehaviour
{

    private List<RoomNode> roomNodes;
    private List<RoomNode> endRoomNodes; // roomNodes that have only one entrance, used for special rooms.

    [SerializeField] private FloorResources floorResources;
    [SerializeField] private GameObject floorsContainer;
    
    public int roomCount; // Number of rooms to generate, apart from starting room.

    public int maxPuzzleRooms; // The max possible amount of puzzle rooms that will be generated. The min is 1
    public int seed;

    // On Start, the floor generation behaviors will be called.
    private void Start()
    {
        // Setting random seed
        int randomSeed = Random.Range(0, int.MaxValue);
        Random.InitState(randomSeed);

        GenerateNodes();
        SetEndRoomNodes();
        SetSpecialRoom(RoomType.bossRoom, true);
        SetSpecialRoom(RoomType.treasureRoom, false);
        SetPuzzleRooms();
        GenerateRooms();
    }

    public void GenerateNodes()
    {
        roomNodes = new List<RoomNode>();

        RoomNode startingNode = new RoomNode();
        startingNode.gridPos = Vector2.zero;
        startingNode.roomType = RoomType.firstRoom;
        startingNode.distanceFromSpawn = 0;

        roomNodes.Add(startingNode);

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
            roomNode.roomType = RoomType.dungeonRoom;
            roomNode.distanceFromSpawn += nodeSpawnedFrom.distanceFromSpawn + 1;
            roomNode.AddNeighborNode(-gridPosShift, nodeSpawnedFrom);
            nodeSpawnedFrom.AddNeighborNode(gridPosShift, roomNode);

            roomNodes.Add(roomNode);

            //Debug.Log(newNodePos.x + ", " + newNodePos.y);

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

    private void SetEndRoomNodes()
    {
        endRoomNodes = new List<RoomNode>();
        foreach (RoomNode roomNode in roomNodes)
        {
            if (roomNode.neighborCount == 1)
            {
                //Debug.Log("Found an end room");
                endRoomNodes.Add(roomNode);
            }
        }
    }

    private void SetSpecialRoom(RoomType roomType, bool setAtFurthestValidEndRoom)
    {
        if (setAtFurthestValidEndRoom)
        {
            int furthestFoundDistance = 0;
            RoomNode currentChosenEndRoomNode = endRoomNodes[0];

            foreach (RoomNode endRoomNode in endRoomNodes)
            {
                //Debug.Log(endRoomNode.distanceFromSpawn);
                if(endRoomNode.roomType == RoomType.dungeonRoom)
                {
                    if(endRoomNode.distanceFromSpawn > furthestFoundDistance)
                    {
                        furthestFoundDistance = endRoomNode.distanceFromSpawn;
                        currentChosenEndRoomNode = endRoomNode;
                    }
                }
            }

            currentChosenEndRoomNode.roomType = roomType;
            //Debug.Log("Boss/NextFloor Room Placed at: " + currentChosenEndRoomNode.distanceFromSpawn + "||" + currentChosenEndRoomNode.ToString());
        }
        else
        {
            int attemptCount = 0;
            bool specialRoomSet = false;
            do
            {
                int randIndex = Random.Range(0, endRoomNodes.Count);
                RoomNode randEndRoomNode = endRoomNodes[randIndex];
                if (randEndRoomNode.roomType == RoomType.dungeonRoom)
                {
                    randEndRoomNode.roomType = roomType;
                    specialRoomSet = true;
                }
                attemptCount++;
            } while (!specialRoomSet && attemptCount > 0);
            
        }
    }

    public void SetPuzzleRooms()
    {
        int puzzleRoomCount = Random.Range(1, maxPuzzleRooms);

        int puzzleRoomsSet = 0;
        int attemptLimit = 30;
        int attempts = 0;

        while(puzzleRoomsSet < maxPuzzleRooms && attempts < attemptLimit)
        {
            attempts++;
            int randomRoomNode = Random.Range(0, roomNodes.Count - 1);

            RoomNode randomNode = roomNodes[randomRoomNode];
            //Debug.Log("RNode Pos: " + randomNode.gridPos);
            if(randomNode.roomType == RoomType.dungeonRoom)
            {
                if (randomNode.neighborRooms.ContainsKey(Vector2.up) &&
                    randomNode.neighborRooms[Vector2.up].roomType == RoomType.puzzleRoom)
                {
                    continue;
                }
                else if(randomNode.neighborRooms.ContainsKey(Vector2.right) &&
                    randomNode.neighborRooms[Vector2.right].roomType == RoomType.puzzleRoom)
                {
                    continue;
                }
                else if (randomNode.neighborRooms.ContainsKey(Vector2.down) &&
                    randomNode.neighborRooms[Vector2.down].roomType == RoomType.puzzleRoom)
                {
                    continue;
                }
                else if (randomNode.neighborRooms.ContainsKey(Vector2.left) &&
                    randomNode.neighborRooms[Vector2.left].roomType == RoomType.puzzleRoom)
                {
                    continue;
                }

                randomNode.roomType = RoomType.puzzleRoom;
                puzzleRoomsSet++;
                //Debug.Log("Puzzle rooms set: " + puzzleRoomsSet);
            }
            //Debug.Log("Attempts: " + attempts);
        }
    }

    // // Places rooms at each room node
    public void GenerateRooms()
    {
        foreach(RoomNode roomNode in roomNodes)
        {
            Room roomPrefab = floorResources.GetRoom(roomNode);
            Vector2 pos = roomNode.gridPos * floorResources.GetRoomScale();
            Room room = Instantiate(roomPrefab, pos, Quaternion.identity, floorsContainer.transform);
            
        }
    }

}
