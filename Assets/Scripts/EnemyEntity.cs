using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public EnemyPathfinding pathfinding;


    public void pathFind(Transform target) {
        Debug.Log($"Pathfinding to transform.Pos{target.position}");
        pathfinding.pathfindTo(target);
    }
}
