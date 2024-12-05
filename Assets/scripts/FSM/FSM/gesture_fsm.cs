using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using AI.FSM;

public class gesture_fsm : AI.FSM.FSMBase
{

    public ActiveStateGroup index_up_activegroup;
    public EnhancedJointVelocityState JointVelocityState;
    public HandJointId _jointToLog = HandJointId.HandStart;
    public RectTransform _uiElement; // UI的RectTransform组件
    public float sensitivity = 10f; // 调整UI运动的敏感度
    protected override void SetUpFSM()
    {
        DefaultState default_state = new DefaultState();
        default_state.AddMap(FSMTriggerID.index_up_shape, FSMStateID.index_up);
        _states.Add(default_state);

        index_upState index_up_state = new index_upState();
        index_up_state.AddMap(FSMTriggerID.index_up_move, FSMStateID.T3);
        index_up_state.AddMap(FSMTriggerID.index_up_rotate, FSMStateID.T4);
        _states.Add(index_up_state);

        T3State t3State = new T3State();
    }
}
