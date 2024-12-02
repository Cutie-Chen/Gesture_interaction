using System;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using TMPro;
using Oculus.Interaction;

public class GestureRotation : MonoBehaviour
{
    [SerializeField]
    private Hand hand;
    private Pose currentPose;
    public HandJointId jointToTrack = HandJointId.HandStart; // ���ٵĹؽڣ�����
    public GameObject objectToRotate; // ��Ҫ��ת������
    private Vector3 lastPosition; // ��һ֡���ֲ�λ��
    private float rotationAngle = 0f; // ��ǰ�������ת�Ƕ�
    private float rotationSpeed = 5f; // ��ת�ٶ�����
    private float movementThreshold = 0.01f; // ��С�ƶ���ֵ
    private float rotationThreshold=5;
    void Start()
    {
        lastPosition = Vector3.zero;
    }

    void Update()
    {
        // ��ȡ��ǰ�ֲ���λ��
        if (hand.GetJointPose(jointToTrack, out Pose currentPose))
        {
            Vector3 currentPosition = currentPose.position;

            // �����ֲ�����һ֡�͵�ǰ֮֡���λ��
            Vector3 movementDelta = currentPosition - lastPosition;

            // ���λ�ƴ�����ֵ�������ж�����
            if (movementDelta.magnitude > movementThreshold)
            {
                // �����ֲ�����ת����XYƽ���ϵ���ת��
                // ������ת������XYƽ���ϣ�ͶӰ��XYƽ��
                Vector3 lastPositionXY = new Vector3(lastPosition.x, lastPosition.y, 0);  // ��z������Ϊ0
                Vector3 currentPositionXY = new Vector3(currentPosition.x, currentPosition.y, 0);  // ��z������Ϊ0

                // ������һ֡�뵱ǰ֡��XYƽ���ϵķ���仯
                Vector3 deltaXY = currentPositionXY - lastPositionXY;

                // ������һ֡�뵱ǰ֮֡��ļн�
                float angle = Vector3.SignedAngle(lastPositionXY, currentPositionXY, Vector3.forward);

                
                // ���ݽǶ��ж���ת���򣬲��ۼ���ת�Ƕ�
                if (Mathf.Abs(angle) > 0.5f) // ��ֹ΢С���µ���ת
                {
                    rotationAngle += angle * rotationSpeed * Time.deltaTime; // ʹ��ԭʼ�Ƕȶ��Ǿ���ֵ
                }

                /* if (Mathf.Abs(angle) > rotationThreshold) // ���λ�ƽǶȱ仯�󣬿����ǻ�Ȧ����
                 {
                     // ��⵽��Ȧ����
                     isCircling = true;
                     rotationAngle += angle * rotationSpeed * Time.deltaTime; // ʹ��ԭʼ�Ƕȶ��Ǿ���ֵ
                 }
                 else
                 {
                     // ����Ƕȱ仯С����Ϊ��ƽ������
                     isCircling = false;
                     objectToMove.transform.position += movementDelta; // ��������ƽ������
                 }*/

                // �����������ת
                objectToRotate.transform.rotation = Quaternion.Euler(0,  0 , rotationAngle);
            }

            // ������һ֡��λ��
            lastPosition = currentPosition;
        }
    }
}
