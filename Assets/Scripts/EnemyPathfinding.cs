using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPathfinding : MonoBehaviour
{
    public Tilemap groundTiles;
    public Tilemap wallTiles;
    private Vector3Int _currentTile;
    private TimeManager _timeManger;
    // Which directions? 
    private readonly List<Vector2> CARDINAL_DIR = new List<Vector2> { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    public void Awake()
    {
        _timeManger = TimeManager.instance;
    }

    public void pathfindTo(Transform target)
    {
        // Gets Current tile. 
        _currentTile = groundTiles.WorldToCell(transform.position);
        List<Vector3Int> ptp = _getPath(target);
        foreach (Vector3Int item in ptp)
        {
            MoveToPosition(item);
        }
    }

    private List<Vector3Int> _getPath(Transform target)
    {
        // Functional programming rocks.. 
        float _heuristic(Vector3Int a, Vector3Int b) => Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
        Vector3Int _convert(Vector3 currPos, Vector2 dir) => groundTiles.WorldToCell(currPos + (Vector3)dir);

        Vector3Int start = _currentTile;
        Vector3Int goal = groundTiles.WorldToCell(target.position);

        // Open list of nodes to evaluate
        List<Vector3Int> openSet = new List<Vector3Int> { start };
        Dictionary<Vector3Int, Vector3Int> cameFrom = new Dictionary<Vector3Int, Vector3Int>();
        Dictionary<Vector3Int, float> gScore = new Dictionary<Vector3Int, float> { [start] = 0 };
        Dictionary<Vector3Int, float> fScore = new Dictionary<Vector3Int, float>
        { [start] = _heuristic(start, goal) };

        while (openSet.Count > 0)
        {
            // Get the tile with the lowest fScore (best candidate)
            Vector3Int current = _getLowestFScore(openSet, fScore);

            // If we have reached the goal, reconstruct the path
            if (current == goal)
            {
                return _reconstructPath(cameFrom, current);
            }

            openSet.Remove(current);

            // Explore neighbors
            foreach (Vector2 direction in CARDINAL_DIR)
            {
                Vector3Int neighbor = _convert(current, direction);

                // If this neighbor is not a valid tile to move to, skip it
                if (!canMove(direction))
                {
                    continue;
                }

                // Calculate gScore (cost to move to neighbor)
                float tentativeGScore = gScore[current] + 1; // All moves have equal cost FOR NOW

                // If this path to neighbor is shorter, or we haven't checked this tile yet
                if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + _heuristic(neighbor, goal);

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        // Return an empty path if no valid path found
        return new List<Vector3Int>();
    }

    // This could be optimized with a PQ, not making one.. Might add this as issue for Week 4
    private Vector3Int _getLowestFScore(List<Vector3Int> openSet, Dictionary<Vector3Int, float> fScore)
    {
        Vector3Int bestNode = openSet[0];
        float bestScore = fScore[bestNode];

        foreach (Vector3Int node in openSet)
        {
            if (fScore[node] < bestScore)
            {
                bestNode = node;
                bestScore = fScore[node];
            }
        }

        return bestNode;
    }
    private List<Vector3Int> _reconstructPath(Dictionary<Vector3Int, Vector3Int> cameFrom, Vector3Int current)
    {
        List<Vector3Int> totalPath = new List<Vector3Int> { current };

        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            totalPath.Insert(0, current); // Build the path backward
        }

        return totalPath;
    }

    public void MoveToPosition(Vector3 pos)
    {
        // take a direction!
        Vector2 direction = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        if (canMove(direction))
        {
            transform.position = pos;
            _currentTile = groundTiles.WorldToCell(transform.position);
        }
    }

    public bool canMove(Vector2 direction)
    {
        // Lets check if we can move.. 
        Vector3Int gridPos = groundTiles.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTiles.HasTile(gridPos) || wallTiles.HasTile(gridPos))
        {
            return false;
        }
        return true;
    }
}
