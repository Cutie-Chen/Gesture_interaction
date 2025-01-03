using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI.FSM
{
    public class transferstate : FSMState
    {
        protected override void init()
        {
            
        }
        public override void OnStateEnter(FSMBase fsm)
        {
            var gesturefsm = fsm as gesture_fsm;
            gesturefsm.translate_transformer.BeginTransform();
        }
        public override void OnStateStay(FSMBase fsm)
        {
            var gesturefsm = fsm as gesture_fsm;
            gesturefsm.translate_transformer.UpdateTransform();
        }
        public override void OnStateExit(FSMBase fsm)
        {
            var gesturefsm = fsm as gesture_fsm;
            gesturefsm.translate_transformer.EndTransform();
        }
    }
}
