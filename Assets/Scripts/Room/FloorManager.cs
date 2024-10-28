using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorManager : MonoBehaviour
{
    public static FloorManager instance;

    public bool doorsAreOpen;
    public List<Room> rooms;

    public FloorResources floorResources;

    public bool developerDoorToggle; // When enabled, pressing k toggles the doors

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        rooms = new List<Room>();
        // DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // if (developerDoorToggle && Input.GetKeyDown(KeyCode.K))
        // {
        //     ToggleDoors();
        // }
    }

    public void CloseDoors()
    {
        doorsAreOpen = false;
        Tile doorTileClosed = floorResources.doorTileClosed;
        ChangeDoorState(doorTileClosed);
    }

    public void OpenDoors()
    {
        doorsAreOpen = true;
        Tile doorTileOpen = floorResources.doorTileOpen;
        ChangeDoorState(doorTileOpen);
    }

    private void ChangeDoorState(Tile doorTile)
    {
        foreach (Room room in rooms)
        {
            BoundsInt bounds = room.doorTilemap.cellBounds;
            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);
                    if (room.doorTilemap.GetTile(tilePosition) != null)
                    {
                        room.doorTilemap.SetTile(tilePosition, doorTile);
                    }
                }
            }
        }
    }

    private void ToggleDoors()
    {
        if (doorsAreOpen)
        {
            CloseDoors();
        }
        else
        {
            OpenDoors();
        }
    }


}
