using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // This music fits 
    // https://youtu.be/RvIEFGPUum8?si=yM2g-9N14hxbod8P
    public static TimeManager instance;
    [HideInInspector]
    private Stack<Action> _futureActions;
    // The current action is on the top of the stack.. 
    private Stack<Action> _previousActions;
    private int _currentActionIndex = 0;
    public void Awake()
    {
        // check for any other inst. 
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // Okay then init
        instance = this;
        _futureActions = new Stack<Action>();
        _previousActions = new Stack<Action>();
        DontDestroyOnLoad(gameObject);
    }
    public void revertAction()
    {
        if (_previousActions.Count == 0)
        {
            return;
        }
        // Gets the previous and pushes it to the future stack.. 
        _currentActionIndex--;
        while (_previousActions.Peek().actionIndex > _currentActionIndex
            && _previousActions.Count != 0)
        {
            // Gets the previous and pushes it to the future stack.. 
            _futureActions.Push(_previousActions.Peek());
            // Revert goes here
            bool check = _revert(_previousActions.Peek());
            if(!check) {
                // Can not be reverted.. 
                break;
            }

            if (_previousActions.TryPop(out var input))
            {
                Debug.Log($"Action: {input.actionType} : {input.actionType} at {input.actionIndex}");
            }
            if (_previousActions.Count == 0)
            {
                break;
            }
        }
    }
    // Add redo for later... 
    private bool _revert(Action act)
    {
        if (act.actionType == Action.TypeOfAction.Movement)
        {
            Debug.Log($"Going back to position: {act.position}");
            PlayerManager.instance.stats.stepReversed();
            return act.mCallback(act.position);
        }
        else if (act.actionType == Action.TypeOfAction.Action) 
        {
            Debug.Log($"Going reverting Action: {act.actionDesc}");
            return act.aCallback(act.actionDesc);
        }
        // This action cannot be reverted.. 
        return false;
    }

    public void IncrementIndex() => _currentActionIndex++;
    public void addAction(Action newAction)
    {
        newAction.actionIndex = _currentActionIndex;
        Debug.Log($"Action: {newAction.actionType} : {newAction.actionType} at {newAction.actionIndex}");
        _previousActions.Push(newAction);
    }
    public Action getPrevAction()
    {
        if (_previousActions.Count == 0)
        {
            // Just return null if nothing is in the stack
            return null;
        }
        return _previousActions.Peek();
    }
}