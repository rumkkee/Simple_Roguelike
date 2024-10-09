using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _controls;

    [SerializeField]
    private Tilemap _groundTitleMap;

    [SerializeField]
    private Tilemap _collisionTileMap;
    private void Awake()
    {
        _controls = new PlayerMovement();
    }
    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }
    void Start()
    {
        _controls.Main.Movement.performed += ctx => move(ctx.ReadValue<Vector2>());
    }

    public void move(Vector2 direction)
    {
        if (!canMove(direction))
        {
            return;
        }
        transform.position += (Vector3)direction;
    }

    public bool canMove(Vector2 direction)
    {
        Vector3Int gridPos = _groundTitleMap.WorldToCell(transform.position + (Vector3)direction);
        if (!_groundTitleMap.HasTile(gridPos) || _collisionTileMap.HasTile(gridPos))
        {
            return false;
        }
        return true;
    }

    public bool checkForDialogue()
    {
        if (DialogueManager.GetInstance().dialogueActive)
        {
            return false;
        }
        return true;
    }

}
