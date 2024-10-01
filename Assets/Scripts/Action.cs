using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Action
{
    // Basicaly, Action index is the move in which an action is done
    // 0 being the intial action, incrementing on the players action
    public int actionIndex;
    // Action types can be expanded later.. 
    public enum TypeOfAction
    {
        Action,
        Movement,
    };
    public delegate void moveCallback(Vector3 pos);
    public moveCallback callback;
    // What the hell are we doing.. 
    public TypeOfAction actionType;
    // IF its a Movement Is then to what position? 
    public Vector3 position;
    // IF its a Action Is then to what position? 
    public string actionDesc;
    public Action(TypeOfAction newType, string newDesc)
    {
        actionType = newType;
        actionDesc = newDesc;
    }
    public Action(TypeOfAction newType, Vector3 lastPos, moveCallback func)
    {
        actionType = newType;
        position = lastPos;
        callback = func;
    }


}