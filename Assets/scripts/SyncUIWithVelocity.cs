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
    private RectTransform _uiElement; // UI的RectTransform组件
    [SerializeField]
    private HandJointId _jointToLog = HandJointId.HandStart;
    [SerializeField]
    private JointVelocityActiveState.RelativeTo _relativeTo = JointVelocityActiveState.RelativeTo.World;
    public EnhancedJointVelocityState velocityState;
    public ActiveStateGroup a;
    public float sensitivity = 10f; // 调整UI运动的敏感度

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
            // 获取特定关节的速度和方向。
            Vector3 wristVelocity = velocityState.GetJointVelocity(_jointToLog);
            Vector3 wristDirection = velocityState.GetJointDirection(_jointToLog, _relativeTo);

            // 如果UI元素被分配，则同步其位置
            if (_uiElement != null)
            {
                // 使用速度更新UI元素的位置
                _uiElement.anchoredPosition += new Vector2(wristVelocity.x, wristVelocity.y) * sensitivity;

                // 设置UI元素的方向（如果需要）
                //_uiElement.rotation = Quaternion.LookRotation(wristDirection.normalized, Vector3.up);
            }
        }
    }
}
