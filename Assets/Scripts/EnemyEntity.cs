using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public EnemyPathfinding pathfinding;


    public void pathFind(Transform target) {
        pathfinding.pathfindTo(target);
    }
}
