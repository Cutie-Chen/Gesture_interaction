using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI.FSM
{
    public class rotateTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            var gesturefsm = fsm as gesture_fsm;
            return IsGrabPointInCubeBounds(gesturefsm.grabbable.GrabPoints[0].position, gesturefsm.grabbable.Transform,gesturefsm.threshold);
            //todo������û���жϵ�ǰ�����Ƿ���ȷ��������Ҫ��ӣ����������ڻ���֪���ж�������ȷ�����ok������ʦ���ˣ�
            //����ǽ���rotatestate��trigger���������һ�ûд����Ϊ�һ��ǲ�֪����ô�˳���
        }

        protected override void init()
        {
            this.TriggerID = FSMTriggerID.rotate;
        }
        private bool IsGrabPointInCubeBounds(Vector3 grabPoint, Transform targetTransform,float th)
        {
            // ��ȡ������ĸ��ǵ�����
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

            // �ж�ץȡ���Ƿ����ĸ��Ƿ�Χ��
            foreach (var corner in cubeCorners)
            {
                if (Vector3.Distance(grabPoint, corner) < th) // �������ú��ʵ���ֵ���ж��Ƿ��ڷ�Χ��
                {
                    return true;
                }
            }

            return false;
        }
    }
}
