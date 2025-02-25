using UnityEngine;

namespace AI.FSM {
    public class GestureFSM : FSMBase {
        [HideInInspector]
        public Object/* todo: 修改这个类型为IGrabbable*/ grabbedItem;
        protected override void SetUpFSM() {
            base.SetUpFSM();

            DefaultState defaultState = new DefaultState();
            defaultState.AddMap(FSMTriggerID.ItemGrabbed, FSMStateID.Select);
            _states.Add(defaultState);

            SelectState selectState = new SelectState();
            selectState.AddMap(FSMTriggerID.GrabPointNearCorner, FSMStateID.Rotate);
            selectState.AddMap(FSMTriggerID.GrabPointAwayCorner, FSMStateID.Translate);
            selectState.AddMap(FSMTriggerID.OutOfItem, FSMStateID.Default);
            selectState.AddMap(FSMTriggerID.NoPose, FSMStateID.Default);
            _states.Add(selectState);

            TranslateState translateState = new TranslateState();
            translateState.AddMap(FSMTriggerID.NoPose, FSMStateID.Default);
            _states.Add(translateState);

            RotateState rotateState = new RotateState();
            rotateState.AddMap(FSMTriggerID.NoPose, FSMStateID.Default);
            _states.Add(rotateState);
        }
    }
}