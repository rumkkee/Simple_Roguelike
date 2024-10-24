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
    public Room activeRoom; // The room the player is in
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

    public delegate void PlayerMove(int steps);
    public static PlayerMove CurrentStepsUpdated;

    private void Start()
    {
        // Get the time manger 
        _timeManInstance = TimeManager.instance;
        _objectCollider = GetComponent<Collider2D>();
        //currentGridPos = activeRoom.groundTilemap.WorldToCell(transform.position);
    }
    private void Update()
    {
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
             Debug.Log($"We moved cells: {currentGridPos}");
            Action movement = new Action(Action.TypeOfAction.Movement, currentGridPos, MoveToPosition);
            StartCoroutine(EnemyManager.instance.doAllEnemyActions(transform));
            currentGridPos = activeRoom.groundTilemap.WorldToCell(transform.position);
            _timeManInstance.IncrementIndex();
            _timeManInstance.addAction(movement);
            //CurrentStepsUpdated(_timeManInstance.)
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
            Vector3Int gridPos = activeRoom.doorTilemap.WorldToCell(transform.position + (Vector3)direction);
            Vector3 movementScale = (Vector3)direction;
            if (activeRoom.doorTilemap.HasTile(gridPos))
            {
                movementScale = (Vector3)direction * 3;
            }
            targetPos = transform.position + movementScale;
            isMoving = true;
            PlayerManager.instance.stats.stepTaken();
            // Debug.Log($"Lets move?: isMoving? {isMoving}");
        }
    }
    public bool CanMove(Vector2 direction)
    {
        if(PlayerManager.instance.stats.remainingSteps() <= 0)
        {
            //Debug.Log("Become unalive");
            return false;
        }

        if (EnemyManager.instance.enemyTurn)
        {
            return false;
        }

        Vector3Int gridPos = activeRoom.groundTilemap.WorldToCell(transform.position + (Vector3)direction);

        if (FloorManager.instance.doorsAreOpen && activeRoom.doorTilemap.HasTile(gridPos)) // also check if doors are open
        {
            return true;
        }
        else if (!activeRoom.groundTilemap.HasTile(gridPos) || activeRoom.collisionTilemap.HasTile(gridPos))
        {
            return false;
        }

        //

        float rayDistance = 1.0f;

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
    public bool MoveToPosition(Vector3 pos)
    {

        // take a direction!
        Vector2 direction = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        if (CanMove(direction))
        {
            transform.position = pos;
            currentGridPos = activeRoom.groundTilemap.WorldToCell(transform.position);
            return true;
        } else {
            return false;
        }
    }
}