using UnityEngine;
using System.Collections;

public class StateIdle : FSMState<AI_FSM, AI_FSM.States>
{
    public override AI_FSM.States StateID
    {
        get { return AI_FSM.States.Idle; }
    }

    static int ticksCount = 0;
    public override void Enter(AI_FSM entity)
    { }

    public override void Execute(AI_FSM entity)
    {
        ticksCount++;

        Debug.Log("IDLE...");

        if (ticksCount >= 5) {
            entity.ChangeState(AI_FSM.States.Attack);
            ticksCount = 0;
        }
     }

    public override void Exit(AI_FSM entity)
    { }
}
