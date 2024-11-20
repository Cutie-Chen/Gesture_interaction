using System;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using TMPro;
using Oculus.Interaction;

public class SyncUIWithVelocity : MonoBehaviour
{
    public TextMeshProUGUI t;
    [SerializeField]
    private RectTransform _uiElement; // UI��RectTransform���
    [SerializeField]
    private HandJointId _jointToLog = HandJointId.HandStart;
    [SerializeField]
    private JointVelocityActiveState.RelativeTo _relativeTo = JointVelocityActiveState.RelativeTo.World;
    public EnhancedJointVelocityState velocityState;
    public ActiveStateGroup a;
    public float sensitivity = 10f; // ����UI�˶������ж�

    private void Awake()
    {
        if (_uiElement == null)
        {
            Debug.LogError("UI Element's RectTransform is not assigned!");
        }
    }

    private void Update()
    {
        if (a.Active)
        {
            // ��ȡ�ض��ؽڵ��ٶȺͷ���
            Vector3 wristVelocity = velocityState.GetJointVelocity(_jointToLog);
            Vector3 wristDirection = velocityState.GetJointDirection(_jointToLog, _relativeTo);

            // ���UIԪ�ر����䣬��ͬ����λ��
            if (_uiElement != null)
            {
                // ʹ���ٶȸ���UIԪ�ص�λ��
                _uiElement.anchoredPosition += new Vector2(wristVelocity.x, wristVelocity.y) * sensitivity;

                // ����UIԪ�صķ��������Ҫ��
                //_uiElement.rotation = Quaternion.LookRotation(wristDirection.normalized, Vector3.up);
            }
        }
    }
}
