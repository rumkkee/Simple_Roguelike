using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorGenerator : MonoBehaviour
{
    // Have a reference to floor resources, room nodes

    [SerializeField] private FloorResources floorResources;
    private GameObject floorsContainer;

    
    [SerializeField] private int roomCount; // Number of rooms to generate, apart from starting room.

    public void StartRoomGeneration()
    {
        GameObject startingRoom = Instantiate(gameObject, floorsContainer.transform.position, Quaternion.identity, floorsContainer.transform);

        int roomsGeneratedCount = 0;

        while (roomsGeneratedCount < roomCount)
        {
            // TODO: Get a random direction



            roomsGeneratedCount++;
        }
    }

}
