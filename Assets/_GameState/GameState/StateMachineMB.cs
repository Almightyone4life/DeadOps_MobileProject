using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMB : MonoBehaviour
{
    public GameState CurrentState { get; private set; }
    private GameState _previousState;

    private bool _inTransition = false;

    public void ChangeState(GameState newState)
    {
        if (CurrentState == newState || _inTransition)
            return;
        ChangeStateSequence(newState);
    }

    public void ChangeStateSequence(GameState newState)
    {
        
        _inTransition = true;
        // run our exit logic before moving to new state
        CurrentState?.Exit();
        StoreStateAsPrevious(newState);

        CurrentState = newState;

        // begin the new state
        CurrentState?.Enter();
        _inTransition = false;
    }

    private void StoreStateAsPrevious(GameState newState)
    {
        // if we don't have a previous state, store the new state as previous
        if (_previousState == null && newState != null)
            _previousState = newState;
        // otherwise, store the current state as previous if we are changing to a new state
        else if (_previousState != null && newState != null)
            _previousState = CurrentState;
    }

    public void ChangeStateToPrevious()
    {
        if (_previousState != null)
            ChangeState(_previousState);
        else 
            Debug.LogWarning("No previous state to return to");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // simulate update tick for the current state
        if (CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }

    protected virtual void FixedUpdate()
    {
        // simulate fixed update tick for the current state
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }

    protected virtual void OnDestroy()
    {
        // clean up the current state when the state machine is destroyed
        CurrentState?.Exit();
    }
}
