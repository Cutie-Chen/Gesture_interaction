namespace AI.FSM {
    public class GrabPointNearCorner : GrabPointChecker {
        public override bool HandleTrigger(FSMBase fsm) {
            return isGrabPointNearCorner(fsm);
        }

        protected override void init() {
            this.TriggerID = FSMTriggerID.GrabPointNearCorner;
        }
    }
}