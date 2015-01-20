using UnityEngine;
using System.Collections;

public class StateAttack : FSMState<AI_FSM, AI_FSM.States>
{
    public override AI_FSM.States StateID
    {
        get { return AI_FSM.States.Attack; }
    }

    public override void Enter(AI_FSM entity)
    {
        Debug.Log("Attack State: Enter");
    }

    public override void Execute(AI_FSM entity)
    {
        Debug.Log("Attack...");
        entity.ChangeState(AI_FSM.States.Cooldown);
    }

    public override void Exit(AI_FSM entity)
    {
        Debug.Log("Attack State: Exit");
    }
}
