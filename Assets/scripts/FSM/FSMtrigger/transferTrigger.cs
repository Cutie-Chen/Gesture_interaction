using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI.FSM
{
    public class transferTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            var gesturefsm = fsm as gesture_fsm;
            return !IsGrabPointInCubeBounds(gesturefsm.grabbable.GrabPoints[0].position, gesturefsm.grabbable.Transform, gesturefsm.threshold);
        }

        protected override void init()
        {
            this.TriggerID = FSMTriggerID.transfer;
        }
        private bool IsGrabPointInCubeBounds(Vector3 grabPoint, Transform targetTransform, float th)
        {
            // 获取物体的四个角的坐标
            Vector3[] cubeCorners = new Vector3[8];
            Vector3 halfExtents = targetTransform.localScale * 0.5f;

            cubeCorners[0] = targetTransform.position + targetTransform.rotation * new Vector3(-halfExtents.x, -halfExtents.y, -halfExtents.z);
            cubeCorners[1] = targetTransform.position + targetTransform.rotation * new Vector3(halfExtents.x, -halfExtents.y, -halfExtents.z);
            cubeCorners[2] = targetTransform.position + targetTransform.rotation * new Vector3(halfExtents.x, -halfExtents.y, halfExtents.z);
            cubeCorners[3] = targetTransform.position + targetTransform.rotation * new Vector3(-halfExtents.x, -halfExtents.y, halfExtents.z);
            cubeCorners[4] = targetTransform.position + targetTransform.rotation * new Vector3(-halfExtents.x, halfExtents.y, -halfExtents.z);
            cubeCorners[5] = targetTransform.position + targetTransform.rotation * new Vector3(halfExtents.x, halfExtents.y, -halfExtents.z);
            cubeCorners[6] = targetTransform.position + targetTransform.rotation * new Vector3(halfExtents.x, halfExtents.y, halfExtents.z);
            cubeCorners[7] = targetTransform.position + targetTransform.rotation * new Vector3(-halfExtents.x, halfExtents.y, halfExtents.z);

            // 判断抓取点是否在四个角范围内
            foreach (var corner in cubeCorners)
            {
                if (Vector3.Distance(grabPoint, corner) < th) // 可以设置合适的阈值来判断是否在范围内
                {
                    return true;
                }
            }

            return false;
        }
    }
}
