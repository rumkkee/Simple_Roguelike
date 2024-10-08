using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How fast a player moves")]
    public float moveSpeed = 5f;
    // Tilemap stuff.. 
    [Header("Tilemap collisions")]
    [SerializeField]
    [Tooltip("The tile map that the ground is on")]
    public Tilemap groundTileMap;
    [SerializeField]
    [Tooltip("The tile map that the collisions are determined is on")]
    public Tilemap collisionTileMap;
    public LayerMask enemyLayerMask;
    // is the player moving?
    [HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public Vector3 targetPos;
    [HideInInspector]
    public Vector3Int currentGridPos;
    private TimeManager _timeManInstance;
    private Collider2D _objectCollider;
    private void Start()
    {
        // Get the time manger 
        _timeManInstance = TimeManager.instance;
        _objectCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        // Check if we moved
        if (currentGridPos != groundTileMap.WorldToCell(transform.position))
        {
            Debug.Log($"We moved cells: {currentGridPos}");
            Action movement = new Action(Action.TypeOfAction.Movement, currentGridPos, MoveToPosition);
            StartCoroutine(EnemyManager.instance.doAllEnemyActions(transform));
            currentGridPos = groundTileMap.WorldToCell(transform.position);
            _timeManInstance.IncrementIndex();
            _timeManInstance.addAction(movement);

        }
        // Not moving don't care lol.. 
        if (!isMoving)
        {
            return;
        }
        // We are movin and grovin
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) < float.Epsilon)
        {
            isMoving = false;

        }
    }
    public static Vector2 SnapCardinal(Vector2 inputDir)
    {
        if (Mathf.Abs(inputDir.x) > Mathf.Abs(inputDir.y))
        {
            return new Vector2(Mathf.Sign(inputDir.x), 0);
        }
        return new Vector2(0, MathF.Sign(inputDir.y));
    }
    public void Move(Vector2 direction)
    {
        // No point and taking direction while moving.. 
        if (isMoving)
        {
            // Debug.Log("Player is already moving");
            return;
        }
        // Lets check if we can move.. 
        if (CanMove(direction))
        {

            targetPos = transform.position + (Vector3)direction;
            isMoving = true;
            // Debug.Log($"Lets move?: isMoving? {isMoving}");
        }
    }
    public bool CanMove(Vector2 direction)
    {
        if (EnemyManager.instance.enemyTurn)
        {
            Debug.Log($"isEnemy turn: {EnemyManager.instance.enemyTurn}");
            return false;
        }

        Vector3Int gridPos = groundTileMap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTileMap.HasTile(gridPos) || collisionTileMap.HasTile(gridPos))
        {
            return false;
        }

        float rayDistance = 1.0f;
        lastDirection = direction;
        Vector2 rayOrigin = _objectCollider.bounds.center;
        // Raycast in the given direction (the direction the player wants to move)
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, rayDistance, enemyLayerMask);

        // Check if there's an enemy in the direction we're trying to move
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy detected in direction: " + direction);
            // We would attack here actually.. 
            return false;
        }

        return true;
    }

    private Vector2 lastDirection;    // Store the last direction for debugging
    void OnDrawGizmosSelected()
    {
        // Set Gizmo color for the ray
        Gizmos.color = Color.red;

        // Draw the ray in the direction of movement
        Vector2 rayOrigin = _objectCollider.bounds.center;
        Gizmos.DrawLine(rayOrigin, (Vector2)rayOrigin + lastDirection * 1.0f);
    }
    public void MoveToPosition(Vector3 pos)
    {
        // take a direction!
        Vector2 direction = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        if (CanMove(direction))
        {
            transform.position = pos;
            currentGridPos = groundTileMap.WorldToCell(transform.position);
        }
    }
}