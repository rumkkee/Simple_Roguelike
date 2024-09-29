using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStack : MonoBehaviour
{
    // So essentually this will allow us to go foward and backwards. 
    private Stack<Action> _futureActions;
    // The current action is on the top of the stack.. 
    private Stack<Action> _previousActions;

    public void addAction(Action newAction)
    {
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
    public Action revertAction()
    {
        // Gets the previous and pushes it to the future stack.. 
        _futureActions.Push(_previousActions.Peek());
        if (_previousActions.TryPop(out var input))
        {
            return input;
        }
        return null;
    }

}