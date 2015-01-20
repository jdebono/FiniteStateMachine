using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_FSM : MonoBehaviour
{
    private const float AI_UPDATE_RATE = 0.5f;

    public enum States
    {
        Idle,
        Attack,
        Cooldown,
    }

    // State
    public StateIdle stateIdle = new StateIdle();
    public StateAttack stateAttack = new StateAttack();
    public StateCooldown stateCooldown = new StateCooldown();

    // The referecne to our state machine
    private FiniteStateMachine<AI_FSM, AI_FSM.States> FSM;

    void Awake()
    {
        CreateStateMachine();

        // Start AIUpdate
        StartCoroutine(OnAIUpdate());
    }

    private void CreateStateMachine()
    {
        // Initialise the State Machine
        FSM = new FiniteStateMachine<AI_FSM, AI_FSM.States>(this);
        FSM.RegisterState(
            new List<FSMState<AI_FSM, AI_FSM.States>> {
                stateIdle,
                stateAttack,
                stateCooldown}
                );

        // Set Default State
        ChangeState(States.Idle);
    }

    public void ChangeState(States newState)
    {
        FSM.ChangeState(newState);
    }

    private IEnumerator OnAIUpdate()
    {
        while(true) {
            AIUpdate();
            yield return new WaitForSeconds(AI_UPDATE_RATE);
        }
    }

    protected virtual void AIUpdate()
    {
        // Call the Update on the State Machine
        FSM.Update();
    }
}
