using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public PlayerStatsManager statsMan;
    public PlayerMovement Movement;
    public PlayerCamera Camera;
    public PlayerActions actions;
    private TimeManager _timeManInstance;
    private PlayerControls _controls;
    private InputAction _action;
    private InputAction _move;
    private void OnEnable() => enableControls();
    private void OnDisable() => disableControls();
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        _controls = new PlayerControls();
        if (Movement == null)
        {
            Movement = GetComponent<PlayerMovement>();
        }
        if (Camera == null)
        {
            Camera = GetComponent<PlayerCamera>();
        }
        _move = _controls.Main.Movement;
        _action = _controls.Main.Action;

        // createPlayerStats();
    }
    private void Start()
    {
        _timeManInstance = TimeManager.instance;
        _controls.Main.Backwards.performed += ctx => reverseActions();
        _controls.Main.Action.performed += ctx => actions.action();
        _controls.Main.UsePotion.performed += ctx => actions.usePotion();
        _controls.Main.switchPotion.performed += ctx => actions.switchPotions();
    }
    // enables controls
    public void enableControls()
    {
        _move.Enable();
        _action.Enable();
        _controls.Enable();
        // Debug.Log("Controls Enabled");
    }
    // disables controls
    public void disableControls()
    {
        _move.Disable();
        _action.Disable();
        _controls.Disable();
        // Debug.Log("Controls Disabled");
    }

    void Update()
    {
        Vector2 moveVec = _move.ReadValue<Vector2>();

        if (moveVec.sqrMagnitude > float.Epsilon)
        {
            Vector2 snapDir = PlayerMovement.SnapCardinal(moveVec);
            // Debug.Log($"snapDir ${snapDir}");
            Vector3 direction = new Vector3(snapDir.x, snapDir.y, 0);
            Movement.Move(direction);
        }
    }

    private void reverseActions()
    {
        disableControls();
        _timeManInstance.revertAction();
        enableControls();
    }
}
