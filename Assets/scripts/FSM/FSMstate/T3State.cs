using AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3State : AI.FSM.FSMState
{
    protected override void init()
    {
        this.StateID = AI.FSM.FSMStateID.T3;
    }
    public override void OnStateStay(FSMBase fsm)
    {
        base.OnStateStay(fsm);
        var gesturefsm = fsm as gesture_fsm;
        var velocity = gesturefsm.JointVelocityState.GetJointposition(gesturefsm._jointToLog);
        gesturefsm._uiElement.anchoredPosition += new Vector2(velocity.x, velocity.y) * gesturefsm.sensitivity;
    }
    
}
