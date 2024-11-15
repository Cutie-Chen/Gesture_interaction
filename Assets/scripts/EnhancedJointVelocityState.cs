using System;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using TMPro;


public class EnhancedJointVelocityState : JointVelocityActiveState
{
        /// <summary>
        /// ��ȡ�ض��ؽڵ��ٶȡ�
        /// </summary>
        /// <param name="jointId">Ҫ��ѯ�Ĺؽ� ID��</param>
        /// <returns>�ؽڵ��ٶ�����������ؽ�δ�ҵ�����Ч���򷵻���������</returns>
        /// 
        public Vector3 GetJointVelocity(HandJointId jointId)
        {
            if (Hand.GetJointPose(jointId, out Pose jointPose) &&
                JointDeltaProvider.GetPositionDelta(jointId, out Vector3 velocity))
            {
                return velocity / Time.deltaTime; // ת��Ϊ�ٶȣ���λ/�룩��
            }
            return Vector3.zero;
        }

        /// <summary>
        /// ��ȡ�ض��ؽڵķ���������
        /// </summary>
        /// <param name="jointId">Ҫ��ѯ�Ĺؽ� ID��</param>
        /// <param name="relativeTo">����Ĳο�����ϵ��</param>
        /// <returns>����������</returns>
        public Vector3 GetJointDirection(HandJointId jointId, RelativeTo relativeTo)
        {
            if (!Hand.GetJointPose(jointId, out Pose jointPose))
            {
                return Vector3.zero;
            }

            switch (relativeTo)
            {
                case RelativeTo.Hand:
                    return jointPose.forward; // ������ֵ�ǰ��������
                case RelativeTo.World:
                    return jointPose.position.normalized; // ���������ķ���������
                case RelativeTo.Head:
                    if (Hmd != null && Hmd.TryGetRootPose(out Pose headPose))
                    {
                        return (jointPose.position - headPose.position).normalized; // �����ͷ���ķ���������
                    }
                    break;
            }
            return Vector3.zero;
        }

        /// <summary>
        /// ��ȡ���йؽڵ��ٶȺͷ���״̬��
        /// </summary>
        /// <returns>�����ٶȺͷ�����ֵ䣬��Ϊ�ؽ����á�</returns>
        public Dictionary<HandJointId, (Vector3 Velocity, Vector3 Direction)> GetAllJointStates()
        {
            Dictionary<HandJointId, (Vector3 Velocity, Vector3 Direction)> jointStates =
                new Dictionary<HandJointId, (Vector3 Velocity, Vector3 Direction)>();

            foreach (var config in FeatureConfigs)
            {
                if (Hand.GetJointPose(config.Feature, out Pose _))
                {
                    Vector3 velocity = GetJointVelocity(config.Feature);
                    Vector3 direction = GetJointDirection(config.Feature, config.RelativeTo);
                    jointStates[config.Feature] = (velocity, direction);
                }
            }

            return jointStates;
        }
        public bool Ifactive()
        {
        if (Active)
            return true;
        else
            return false;
        }
    }

