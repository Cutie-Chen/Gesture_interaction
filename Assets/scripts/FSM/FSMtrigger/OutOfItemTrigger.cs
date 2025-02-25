namespace AI.FSM {
    public class OutOfItemTrigger : FSMTrigger {
        public override bool HandleTrigger(FSMBase fsm) {
            // todo: 检查InteractableGroupView的SelectingInteractorsCount是否为零
            //       如果后期有多个可操作的物体，也就是有多个InteractableView，那么这里的条件是总和为0
            throw new System.NotImplementedException();
        }

        protected override void init() {
            this.TriggerID = FSMTriggerID.OutOfItem;
        }
    }
}