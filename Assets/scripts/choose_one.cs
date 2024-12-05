using System;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using TMPro;
using Oculus.Interaction;
using UnityEngine.EventSystems;

public class choose_one : MonoBehaviour
{
    [SerializeField]
    private Hand hand;
    public HandJointId jointToTrack = HandJointId.HandStart; // 跟踪的关节，手腕
    [SerializeField]
    public GameObject objectToSelect; // 需要选择的 UI 元素（UI 物体）
    private RectTransform objectRectTransform;
    public bool isselect;
    public TextMeshProUGUI t;
    
    void Start()
    {
        // 获取物体的 RectTransform 组件
        objectRectTransform = objectToSelect.GetComponent<RectTransform>();

        if (objectRectTransform == null)
        {
            Debug.LogError("The object does not have a RectTransform component.");
        }
    }
    // Start is called before the first frame update
    public bool IsJointInsideObject(Vector3 handPosition)
    {
        // 获取 UI 元素的世界坐标范围
        //EventSystem system = new EventSystem();
        //system.RaycastAll()
        Vector3[] worldCorners = new Vector3[4];
        objectRectTransform.GetWorldCorners(worldCorners);
        
        // 获取 UI 元素的 2D 边界框
        Vector3 topLeft = worldCorners[1];  // 左上角
        Vector3 bottomRight = worldCorners[3];  // 右下角

        // 获取手部关节的位置，并投影到屏幕空间
        Vector3 jointPosition = new Vector3(handPosition.x, handPosition.y, 0);  // 忽略 Z 轴

        // 判断关节是否在 UI 元素的边界框内
        bool isInside = jointPosition.x >= topLeft.x && jointPosition.x <= bottomRight.x &&
                        jointPosition.y >= bottomRight.y && jointPosition.y <= topLeft.y;

        return isInside;
    }

    // 更新每一帧并检查手势关节是否在物体内
    void Update()
    {
        Pose currentPose;

        // 获取当前手部关节的位置
        if (hand.GetJointPose(jointToTrack, out currentPose))
        {
            Vector3 handPosition = currentPose.position;  // 获取关节位置

            // 判断关节是否在物体范围内
            bool isInside = IsJointInsideObject(handPosition);
            if (isInside)
            {
                isselect = true;
            }
            else
            {
                isselect = false;
            }
        }
        if (isselect)
            t.text = "选中了";
        else
            t.text = "未选中";
    }
}
