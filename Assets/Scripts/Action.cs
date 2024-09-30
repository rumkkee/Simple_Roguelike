using System;
using UnityEngine;

[Serializable]
public class Action {
    public int actionIndex; 
    public bool isMovement;
    public Transform position;
    public bool isAction;
    public string actionDesc;
}