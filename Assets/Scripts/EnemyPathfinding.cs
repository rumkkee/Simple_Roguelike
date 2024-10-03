using System.Collections.Generic;
using UnityEngine;
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


        return new List<Vector3Int>();

    }

    private float _checkTile(Vector2 direction, Vector3Int currentTile) {


        return 0.0f;
    }

    private bool _compareFloat(float compare1, float compare2) {
        const float TOLERLANCE = 1e-5f;
        // How close can a float be? Before its equal? 
        float diff = Mathf.Abs(compare1 - compare2);
        return diff <= TOLERLANCE;
    }
}
