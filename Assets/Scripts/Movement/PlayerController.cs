using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How fast a player moves")]
    public float moveSpeed = 5f;
    private PlayerMovement _controls;
    private InputAction _move;
    private bool _isMoving;
    private Vector3 _targetPos;
    // Tilemap stuff.. 
    [Header("Tilemap collisions")]
    [SerializeField]
    [Tooltip("The tile map that the ground is on")]
    private Tilemap _groundTileMap;

    [SerializeField]
    [Tooltip("The tile map that the collisions are determined is on")]
    private Tilemap _collisionTileMap;
    private void Awake()
    {
        _controls = new PlayerMovement();
        _move = _controls.Main.Movement;
    }
    private void OnEnable()
    {
        _move.Enable();
    }
    private void OnDisable()
    {
        _move.Disable();
    }
    void Update()
    {
        if (!_isMoving)
        {
            Vector2 moveVec = _move.ReadValue<Vector2>();

            if (moveVec.sqrMagnitude > 0.1f)
            {
                Vector3 direction = new Vector3(moveVec.x, moveVec.y, 0);
                move(direction);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _targetPos) < float.Epsilon)
            {
                _isMoving = false;
            }
        }
    }

    public void move(Vector2 direction)
    {
        if (canMove(direction))
        {
            _targetPos = transform.position + (Vector3)direction;
            _isMoving = true;
        }
    }
    public bool canMove(Vector2 direction)
    {
        Vector3Int gridPos = _groundTileMap.WorldToCell(transform.position + (Vector3)direction);
        if (!_groundTileMap.HasTile(gridPos) || _collisionTileMap.HasTile(gridPos))
        {
            return false;
        }
        return true;
    }
}
