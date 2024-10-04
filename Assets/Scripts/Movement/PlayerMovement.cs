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
    // is the player moving?
    [HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public Vector3 targetPos;
    [HideInInspector]
    public Vector3Int currentGridPos;
    private TimeManager _timeManInstance;
    private void Start()
    {
        // Get the time manger 
        _timeManInstance = TimeManager.instance;
    }
    private void Update()
    {
        // Check if we moved
        if (currentGridPos != groundTileMap.WorldToCell(transform.position))
        {
            Debug.Log($"We moved cells: {currentGridPos}");
            Action movement = new Action(Action.TypeOfAction.Movement, currentGridPos, MoveToPosition);
            currentGridPos = groundTileMap.WorldToCell(transform.position);
            _timeManInstance.IncrementIndex();
            _timeManInstance.addAction(movement);
        }
        // If we not moved 
        if (!isMoving)
        {
            return;
        }
        // We did move
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) < float.Epsilon)
        {
            isMoving = false;

        }
    }
    public static Vector2 snapCardinal(Vector2 inputDir)
    {
        if (Mathf.Abs(inputDir.x) > Mathf.Abs(inputDir.y))
        {
            return new Vector2(Mathf.Sign(inputDir.x), 0);
        }
        return new Vector2(0, MathF.Sign(inputDir.y));
    }
    public void Move(Vector2 direction)
    {
        if (canMove(direction))
        {
            targetPos = transform.position + (Vector3)direction;
            isMoving = true;
        }
    }
    public bool canMove(Vector2 direction)
    {
        Vector3Int gridPos = groundTileMap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTileMap.HasTile(gridPos) || collisionTileMap.HasTile(gridPos))
        {
            return false;
        }
        return true;
    }
    public void MoveToPosition(Vector3 pos)
    {
        Vector2 direction = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        if (canMove(direction))
        {
            transform.position = pos;
            currentGridPos = groundTileMap.WorldToCell(transform.position);
        }
    }
}