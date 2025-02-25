namespace AI.FSM {
    public abstract class GrabPointChecker : FSMTrigger {
        protected bool isGrabPointNearCorner(FSMBase fsm) {
            // todo: 从fsm中获取已被选中的grabbedItem，访问他的GrabPoints属性，对其中第一个Point进行检测
            //       检查第一个Point是否靠近grabbedItem.transform的角落
            throw new System.NotImplementedException();
        }
    }
}