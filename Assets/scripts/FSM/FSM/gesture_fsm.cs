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
    //public RectTransform _uiElement; // UI��RectTransform���
    //public float sensitivity = 10f; // ����UI�˶������ж�
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
        //1.��������Ҫʹ�õ�state
        index_upState index_up_state = new index_upState();
        //2.���뵽_states������
        //3.Ϊ��ǰ״̬��ÿһ������ʹ��addmap������
        index_up_state.AddMap(FSMTriggerID.index_up_move, FSMStateID.T3);
        index_up_state.AddMap(FSMTriggerID.index_up_rotate, FSMStateID.T4);
        _states.Add(index_up_state);

        T3State t3State = new T3State();
    }
}
