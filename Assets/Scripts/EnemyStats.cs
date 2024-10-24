using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This exists for saving
[CreateAssetMenu(fileName = "EnemyStatsObject", menuName = "Enemy Stats Object")]
public class EnemyStats : ScriptableObject {
    public int startingHealth;
    public int defence;
}