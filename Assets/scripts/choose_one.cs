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
    public HandJointId jointToTrack = HandJointId.HandStart; // ���ٵĹؽڣ�����
    [SerializeField]
    public GameObject objectToSelect; // ��Ҫѡ��� UI Ԫ�أ�UI ���壩
    private RectTransform objectRectTransform;
    public bool isselect;
    public TextMeshProUGUI t;
    
    void Start()
    {
        // ��ȡ����� RectTransform ���
        objectRectTransform = objectToSelect.GetComponent<RectTransform>();

        if (objectRectTransform == null)
        {
            Debug.LogError("The object does not have a RectTransform component.");
        }
    }
    // Start is called before the first frame update
    public bool IsJointInsideObject(Vector3 handPosition)
    {
        // ��ȡ UI Ԫ�ص��������귶Χ
        //EventSystem system = new EventSystem();
        //system.RaycastAll()
        Vector3[] worldCorners = new Vector3[4];
        objectRectTransform.GetWorldCorners(worldCorners);
        
        // ��ȡ UI Ԫ�ص� 2D �߽��
        Vector3 topLeft = worldCorners[1];  // ���Ͻ�
        Vector3 bottomRight = worldCorners[3];  // ���½�

        // ��ȡ�ֲ��ؽڵ�λ�ã���ͶӰ����Ļ�ռ�
        Vector3 jointPosition = new Vector3(handPosition.x, handPosition.y, 0);  // ���� Z ��

        // �жϹؽ��Ƿ��� UI Ԫ�صı߽����
        bool isInside = jointPosition.x >= topLeft.x && jointPosition.x <= bottomRight.x &&
                        jointPosition.y >= bottomRight.y && jointPosition.y <= topLeft.y;

        return isInside;
    }

    // ����ÿһ֡��������ƹؽ��Ƿ���������
    void Update()
    {
        Pose currentPose;

        // ��ȡ��ǰ�ֲ��ؽڵ�λ��
        if (hand.GetJointPose(jointToTrack, out currentPose))
        {
            Vector3 handPosition = currentPose.position;  // ��ȡ�ؽ�λ��

            // �жϹؽ��Ƿ������巶Χ��
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
            t.text = "ѡ����";
        else
            t.text = "δѡ��";
    }
}
