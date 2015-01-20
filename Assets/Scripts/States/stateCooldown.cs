using UnityEngine;
using System.Collections;

public class StateCooldown : FSMState<AI_FSM, AI_FSM.States>
{
    public override AI_FSM.States StateID
    {
        get { return AI_FSM.States.Cooldown; }
    }

    public override void Enter(AI_FSM entity)
    { }

    public override void Execute(AI_FSM entity)
    {
        Debug.Log("CoolDown...");
        entity.ChangeState(AI_FSM.States.Idle);
    }

    public override void Exit(AI_FSM entity)
    { }
}
