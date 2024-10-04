using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPathfinding : MonoBehaviour
{
    public Tilemap groundTiles;
    public Tilemap wallTiles;
    public float EnemyMoveSpeed;
    public float spriteOffset = 0.5f;
    private Vector3Int _currentTile;
    private TimeManager _timeManger;
    // Which directions? 
    private readonly List<Vector2> _CARDINAL_DIR = new List<Vector2> {Vector2.left, Vector2.right, Vector2.up, Vector2.down };

    public void Awake()
    {
        _timeManger = TimeManager.instance;
    }

    public void pathfindTo(Transform target)
    {
        // Gets Current tile. 
        Vector3 pos = transform.position;
        _currentTile = groundTiles.WorldToCell(pos);

        // we only need to run this when something major changes.. 
        List<Vector3Int> ptp = _getPath(target);
        foreach (Vector3Int item in ptp)
        {
            Debug.Log(item);
        }
        Debug.Log($"Size of path {ptp.Count}");
        if (ptp.Count < 1)
        {
            Debug.LogWarning("No valid path found!");
            return;
        }
        Debug.Log($"Moving to {ptp[1]} from {_currentTile}");
        StartCoroutine(MoveToPosition(groundTiles.CellToWorld(ptp[1])));
    }

    private List<Vector3Int> _getPath(Transform target)
    {
        // Functional programming rocks.. 
        float _heuristic(Vector3Int a, Vector3Int b) => Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);

        Vector3Int start = _currentTile;
        Vector3Int goal = groundTiles.WorldToCell(target.position);

        // Open list of nodes to evaluate
        List<Vector3Int> openSet = new List<Vector3Int> { start };
        HashSet<Vector3Int> closedSet = new HashSet<Vector3Int>();
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
            closedSet.Add(current);
            Debug.Log(openSet.Count);

            // Explore neighbors
            foreach (Vector2 direction in _CARDINAL_DIR)
            {
                Vector3Int neighbor = current + new Vector3Int((int)direction.x, (int)direction.y, 0);
                if (closedSet.Contains(neighbor) || !canMove(neighbor))
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
        Debug.Log("No Valid path");
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

    public IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // targetPosition.x += spriteOffset;
        // targetPosition.y += spriteOffset; 
        while (Vector3.Distance(transform.position, targetPosition) > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemyMoveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }

    public bool canMove(Vector3Int gridPos)
    {
        // Lets check if we can move.. 
        if (!groundTiles.HasTile(gridPos) || wallTiles.HasTile(gridPos))
        {
            return false;
        }
        return true;
    }
}
