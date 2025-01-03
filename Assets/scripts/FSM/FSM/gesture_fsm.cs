using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using AI.FSM;

public class gesture_fsm : AI.FSM.FSMBase
{

    //public ActiveStateGroup index_up_activegroup;
    //public EnhancedJointVelocityState JointVelocityState;
    //public HandJointId _jointToLog = HandJointId.HandStart;
    //public RectTransform _uiElement; // UI的RectTransform组件
    //public float sensitivity = 10f; // 调整UI运动的敏感度
    public OneGrabRotateTransformer rotate_transformer;
    public OneGrabTranslateTransformer translate_transformer;
    public IGrabbable grabbable;
    public float threshold;
    protected override void SetUpFSM()
    {
        DefaultState default_state = new DefaultState();
        default_state.AddMap(FSMTriggerID.rotate, FSMStateID.rotate);
        default_state.AddMap(FSMTriggerID.transfer, FSMStateID.transfer);
        _states.Add(default_state);
        //1.创建所有要使用的state
        index_upState index_up_state = new index_upState();
        //2.加入到_states数组里
        //3.为当前状态的每一个出边使用addmap方法。
        index_up_state.AddMap(FSMTriggerID.index_up_move, FSMStateID.T3);
        index_up_state.AddMap(FSMTriggerID.index_up_rotate, FSMStateID.T4);
        _states.Add(index_up_state);

        T3State t3State = new T3State();
    }
}
