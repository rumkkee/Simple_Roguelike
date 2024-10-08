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
    public delegate bool moveCallback(Vector3 pos);
    public moveCallback mCallback;
    public delegate bool actionCallback(string desc);
    public actionCallback aCallback;
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
        mCallback = func;
    }


}