using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Tilemaps;

public class EnemyPathfinding : MonoBehaviour
{
    public Tilemap groundTiles;
    public Tilemap wallTiles;
    private Vector3Int _currentTile;
    private TimeManager _timeManger; 

    public void Awake() {
        _timeManger = TimeManager.instance;
    }

    public void pathfindTo(Transform target)
    {
        // Gets Current tile. 
        _currentTile = groundTiles.WorldToCell(transform.position);
        List<Vector3Int> ptp = _getPath(target);
    }

    // Returns the tiles we need to go to.. 
    private List<Vector3Int> _getPath(Transform target)
    {   
        // Four cardinal directions
        float upWeight = _checkTile(Vector2.up, _currentTile);
        float downWeight = _checkTile(Vector2.down, _currentTile);
        float leftWeight = _checkTile(Vector2.left, _currentTile);
        float rightWeight = _checkTile(Vector2.right, _currentTile);

        

    }

    private float _checkTile(Vector2 direction, Vector3Int currentTile) {

    }
}
