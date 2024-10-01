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
    private TimeManager _timeManInstance;
    private PlayerMovement _controls;
    private InputAction _move;
    private InputAction _action;
    private bool _isMoving;
    private bool _isReverting;
    private Vector3 _targetPos;
    private Vector3Int _currentGridPos;
    // Tilemap stuff.. 
    [Header("Tilemap collisions")]
    [SerializeField]
    [Tooltip("The tile map that the ground is on")]
    private Tilemap _groundTileMap;

    [SerializeField]
    [Tooltip("The tile map that the collisions are determined is on")]
    private Tilemap _collisionTileMap;
    private void OnEnable() => enableControls();
    private void OnDisable() => disableControls();
    private void Awake()
    {
        _controls = new PlayerMovement();
        _move = _controls.Main.Movement;
        _action = _controls.Main.Action;
    }
    private void Start()
    {
        _timeManInstance = TimeManager.instance;
        _controls.Main.Backwards.performed += reverseActions;
        _controls.Main.Action.performed += action;
    }
    public void enableControls()
    {
        _move.Enable();
        _action.Enable();
        _controls.Enable();
    }
    public void disableControls()
    {
        _move.Disable();
        _action.Disable();
        _controls.Disable();
    }

    void Update()
    {
        if (_currentGridPos != _groundTileMap.WorldToCell(transform.position))
        {
            Debug.Log($"We moved cells: {_currentGridPos}");
            // If its not our move its ignore.. 
            if (_isReverting)
            {
                return;
            }
            Action movement = new Action(Action.TypeOfAction.Movement, _currentGridPos, MoveToPosition);
            _currentGridPos = _groundTileMap.WorldToCell(transform.position);
            _timeManInstance.IncrementIndex();
            _timeManInstance.addAction(movement);

        }
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _targetPos) < float.Epsilon)
            {
                _isMoving = false;

            }
            return;
        }

        Vector2 moveVec = _move.ReadValue<Vector2>();

        if (moveVec.sqrMagnitude > float.Epsilon)
        {
            Vector2 snapDir = _snapCardinal(moveVec);
            Vector3 direction = new Vector3(snapDir.x, snapDir.y, 0);
            Move(direction);
        }
    }

    private Vector2 _snapCardinal(Vector2 inputDir)
    {
        if (Mathf.Abs(inputDir.x) > Mathf.Abs(inputDir.y))
        {
            return new Vector2(Mathf.Sign(inputDir.x), 0);
        }
        return new Vector2(0, MathF.Sign(inputDir.y));
    }

    private void reverseActions(InputAction.CallbackContext context)
    {
        disableControls();
        _timeManInstance.revertAction();
        enableControls();
    }

    public void Move(Vector2 direction)
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
    public void MoveToPosition(Vector3 pos)
    {
        Vector2 direction = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        if (canMove(direction))
        {
            transform.position = pos;
            _currentGridPos = _groundTileMap.WorldToCell(transform.position);
        }
    }
    public void action(InputAction.CallbackContext context) {
        Debug.Log("Action done!");
    }
}
