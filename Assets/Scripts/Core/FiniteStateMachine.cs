using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine<T, U>
{
    private T _owner;
    private FSMState<T, U> _currentState = null;
    private FSMState<T, U> _previousState = null;
    private Dictionary<U, FSMState<T, U>> _stateDictionary = new Dictionary<U, FSMState<T, U>>();

    public FiniteStateMachine(T owner)
    {
        _owner = owner;
    }

    public void Update()
    {
        if (_currentState != null) _currentState.Execute(_owner);
    }

    public void ChangeState(U newState)
    {
        _previousState = _currentState;

        if (_currentState != null)
            _currentState.Exit(_owner);

        if (_stateDictionary.ContainsKey(newState)) {
            _currentState = _stateDictionary[newState];

            if (_currentState != null)
                _currentState.Enter(_owner);
        } else {
            Debug.LogError(newState.ToString() + " is not Registered.");
        }
    }

    public void RevertToPreviousState()
    {
        if (_previousState != null)
            ChangeState(_previousState.StateID);
    }

    public void RegisterState(FSMState<T, U> state)
    {
        _stateDictionary.Add(state.StateID, state);
    }

    public void RegisterState(List<FSMState<T, U>> stateList)
    {
        foreach (var state in stateList) {
            RegisterState(state);
        }
    }

    public void UnregisterState(FSMState<T, U> state)
    {
        _stateDictionary.Remove(state.StateID);
    }
}
