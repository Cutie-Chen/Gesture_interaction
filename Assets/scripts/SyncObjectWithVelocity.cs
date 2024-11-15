using System;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using TMPro;
using Oculus.Interaction;
public class SyncObjectWithVelocity : MonoBehaviour
{
    public TextMeshProUGUI t;
    [SerializeField]
    //private JointVelocityData jointVelocityData;  
    private Rigidbody _rigidbody;
    [SerializeField]
    private HandJointId _jointToLog = HandJointId.HandStart;
    private JointVelocityActiveState.RelativeTo _relativeTo = JointVelocityActiveState.RelativeTo.World;
    public EnhancedJointVelocityState e;
    public ActiveStateGroup a;
    private void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update(){
        //if (jointVelocityData != null)
        //{
            // ��ȡ�ؽڵ��ٶȺͷ���
            //Vector3 velocity = jointVelocityData.velocity;
            //Vector3 direction = jointVelocityData.direction;
            EnhancedJointVelocityState velocityState = e.GetComponent<EnhancedJointVelocityState>();
        if (a.Active)
        {
            // ��ȡ�ض��ؽڵ��ٶȺͷ���
            Vector3 wristVelocity = velocityState.GetJointVelocity(_jointToLog);
            Vector3 wristDirection = velocityState.GetJointDirection(_jointToLog, _relativeTo);
            t.text = wristVelocity.ToString();
            /*// ��ȡ���йؽڵ�״̬��
            var jointStates = velocityState.GetAllJointStates();
            foreach (var jointState in jointStates)
            {
                Debug.Log($"Joint: {jointState.Key}, Velocity: {jointState.Value.Velocity}, Direction: {jointState.Value.Direction}");
            }*/

            //t.text = velocity.ToString();
            //Debug.Log(velocity);
            //Debug.Log(direction);
            // ��������ٶ�����Ϊ�ؽڵ��ٶ�
            if (_rigidbody != null)
            {
                _rigidbody.velocity = wristVelocity;

                transform.forward = wristDirection.normalized; // ���������ǰ������

            }
        }
        //}
    }
}
