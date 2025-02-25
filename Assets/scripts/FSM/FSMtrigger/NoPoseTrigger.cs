namespace AI.FSM {
    public class NoPoseTrigger : FSMTrigger {
        public override bool HandleTrigger(FSMBase fsm) {
            // todo: 检查InteractableGroupView的State属性是否是Normal
            //       如果后期有多个可操作的物体，也就是有多个InteractableView，那么这里的条件是所有的都是Normal
            throw new System.NotImplementedException();
        }

        protected override void init() {
            this.TriggerID = FSMTriggerID.NoPose;
        }
    }
}