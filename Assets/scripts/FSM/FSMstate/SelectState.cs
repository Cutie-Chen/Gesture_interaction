namespace AI.FSM {
    public class SelectState : FSMState {
        protected override void init() {
            this.StateID = FSMStateID.Select;
        }
        public override void OnStateEnter(FSMBase fsm) {
            base.OnStateEnter(fsm);
            // todo
        }
        public override void OnStateStay(FSMBase fsm) {
            base.OnStateStay(fsm);
            var gestureFSM = fsm as GestureFSM;
            // todo: 将选中的物体保存到gestureFSM
        }
        public override void OnStateExit(FSMBase fsm) {
            base.OnStateExit(fsm);
            // todo
        }
    }
}