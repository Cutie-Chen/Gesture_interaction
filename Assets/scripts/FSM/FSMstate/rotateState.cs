using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI.FSM {
    public class rotateState : FSMState
    {
        protected override void init()
        {
            this.StateID = AI.FSM.FSMStateID.rotate;
        }
        public override void OnStateEnter(FSMBase fsm)
        {

            var gesturefsm = fsm as gesture_fsm;
            gesturefsm.rotate_transformer.BeginTransform();

        }
        public override void OnStateStay(FSMBase fsm)
        {
            var gesturefsm = fsm as gesture_fsm;
            gesturefsm.rotate_transformer.UpdateTransform();
        }
        public override void OnStateExit(FSMBase fsm)
        {
            var gesturefsm = fsm as gesture_fsm;
            gesturefsm.rotate_transformer.EndTransform();
        }
    }
}