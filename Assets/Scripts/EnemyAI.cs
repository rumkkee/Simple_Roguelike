
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // INOHA - Seventh Heaven
    // https://youtu.be/OY_VKLKUMLI?si=B7ZVZJFMNBoz6Ovy
    // Decision making for the enemmies
    public float aggressionRange;
    public float attackRange;
    public EnemyPathfinding pathfinding;
    // Not all will be implmented but for good for future issues. 
    public enum AIType
    {
        MELEE, // Self explainatory. 
        SUPPORT, // Be (Expletive deleted) .. and stay near other enemies.. 
        RANGED, // be a little (Expletive deleted) and stay away from the player.
        SUICIDE // take yourself out on your terms by aggressivly attacking the player. Maybe exploding to death.. 
    }
    public AIType behaviorType;
    // Hi this is alex by the way 🙂🎸✌️ 

    public void makeDecision(PlayerStats stats, Transform playerPos)
    {
        // Get shortest path.. 

        // (Expletive deleted) ..  Am not sure if my little rant would be okay in the codebase? 
        // Hi, Dr C.
        switch (behaviorType)
        {
            case AIType.MELEE:
                _meleeDecisions(stats, playerPos);
                break;
            case AIType.RANGED:
                break;
            case AIType.SUICIDE:
                _suicideDecisions(stats, playerPos);
                break;
            case AIType.SUPPORT:
                break;
        }

    }

    private void _meleeDecisions(PlayerStats stats, Transform playerPos)
    {
        List<Vector3Int> path = pathfinding.getPath(playerPos);
        // This code base needs a hero.. AM NOT DOING THAT JOKE. 
        if (path.Count < 1)
        {
            Debug.LogWarning("No valid path found!");
            return;
        }

    }

    private void _suicideDecisions(PlayerStats stats, Transform playerPos)
    {
        List<Vector3Int> path = pathfinding.getPath(playerPos);
        // Yeah we aint going in front of the player.. 
        if (path.Count < 1)
        {
            Debug.LogWarning("No valid path found!");
            return;
        }


        // The oldest xbox known to man
    }
}
